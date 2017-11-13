using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BootChatClient
{
    public partial class ChatRoomInterface : Form
    {
        public ChatRoomInterface()
        {
            InitializeComponent();
        }

        private Dictionary<String, Object> messages = new Dictionary<String, Object>();
        private volatile Boolean newMessage = false;
        private String currentUser = String.Empty;
        private BackgroundWorker worker = new BackgroundWorker();
        private volatile Boolean tick = true;
        private volatile Boolean complete = false;

        private void ChatRoomInterface_Load(object sender, EventArgs e)
        {
            worker.DoWork += Worker_DoWork;

            worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            complete = false;
            while (tick)
            {
                Dictionary<String, Object> inboxStatus = Program.agent.getInboxStatus();
                Boolean success = Convert.ToBoolean(inboxStatus["success"]);
                if (success)
                {
                    int nm = Convert.ToInt32(inboxStatus["new"]);
                    if (newMessage = nm > 0)
                    {
                        updateInboxList();
                        updateConvo();
                        Program.agent.setNewMessage(false);
                    }

                    for(int i = 0; i < 30 && tick; i++)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
                else
                {
                    tick = false;
                    Program.agent.DebugPrintDictionary(inboxStatus);
                }
            }
            complete = true;
            ChatRoomInterface_FormClosed(null, null);
        }

        private void ChatRoomInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Exit();
        }

        private void updateInboxList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    updateInboxList();
                });
                return;
            }
            messages = Program.agent.getAllMessages();
            Boolean success = Convert.ToBoolean(messages["success"]);
            if (success)
            {
                //lstInbox.Items.Clear();
                foreach (Object message in (Object[])messages["messages"])
                {
                    Dictionary<String, Object> mmessage = (Dictionary<String, Object>)message;
                    if (!lstInbox.Items.Contains(mmessage["from_user"]) && Convert.ToString(mmessage["from_user"]) != Program.agent.getUsername())
                    {
                        lstInbox.Items.Add(mmessage["from_user"]);
                    }
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(messages["exception"]));
                tick = false;
            }
        }

        private void updateConvo()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    updateConvo();
                });
                return;
            }

            Boolean success = Convert.ToBoolean(messages["success"]);
            if (!success)
            {
                MessageBox.Show(Convert.ToString(messages["exception"]));
                return;
            }
 
            StringBuilder sb = new StringBuilder();
            foreach (Object row in (Object[])messages["messages"])
            {
                Dictionary<String, Object> message = (Dictionary<String, Object>)row;
                String from = Convert.ToString(message["from_user"]);
                String to = Convert.ToString(message["to_user"]);
                if (from == currentUser || to == currentUser)
                {
                    sb.AppendLine(String.Format("{0}: {1}", message["from_user"], message["body"]));
                }
            }
            txtConvo.Text = sb.ToString();
            txtConvo.SelectionStart = txtConvo.Text.Length;
            txtConvo.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(currentUser.Length > 0)
            {
                Dictionary<String, Object>  result = Program.agent.sendMessage(currentUser, txtReply.Text);
                Boolean success = Convert.ToBoolean(result["success"]);
                if (success)
                {
                    updateInboxList();
                    updateConvo();
                    txtReply.Clear();
                }
                else
                {
                    MessageBox.Show(Convert.ToString(result["exception"]));
                }
            }
        }

        private void lstInbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstInbox.SelectedIndex > -1)
            {
                currentUser = lstInbox.SelectedItem.ToString();
                updateConvo();
            }
            else
            {
                currentUser = String.Empty;
            }
        }

        private void txtConvo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ChatRoomInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            tick = false;
        }

        private void btnCreateNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendTo st = new SendTo();
            st.ShowDialog();
        }
    }
}
