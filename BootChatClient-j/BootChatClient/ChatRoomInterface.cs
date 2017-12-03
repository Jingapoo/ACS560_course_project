using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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
        private volatile int lastNumberOfMessages = 0;
        private volatile int lastNumberOfInbox = 0;
        private Boolean firstload = false;
        private volatile Boolean loggingOut = false;


        private void ChatRoomInterface_Load(object sender, EventArgs e)
        {
            worker.DoWork += Worker_DoWork;

            worker.RunWorkerAsync();

            SoundPlayer s = new SoundPlayer(BootChatClient.Properties.Resources.dooropen);
            s.Play();
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
                        if (!tick)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    tick = false;
                    Program.agent.DebugPrintDictionary(inboxStatus);
                }
            }
            complete = true;

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }
            catch (Exception) { }
        }

        private void ChatRoomInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!complete)
            {
                tick = false;
                e.Cancel = true;
            }
        }

        private void ChatRoomInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loggingOut)
            {
                Program.Exit();
            }
            else
            {
                Program.agent.Logout();
            }
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
                int numInbox = 0;

                foreach (Object message in (Object[])messages["messages"])
                {
                    Dictionary<String, Object> mmessage = (Dictionary<String, Object>)message;
                    if (!lstInbox.Items.Contains(mmessage["from_user"]) && Convert.ToString(mmessage["from_user"]) != Program.agent.getUsername())
                    {
                        lstInbox.Items.Add(mmessage["from_user"]);
                        numInbox++;
                    }
                }

                if(lstInbox.Items.Count > 0)
                {
                    if(lstInbox.Items.Count > lastNumberOfInbox && firstload)
                    {
                        SoundPlayer s = new SoundPlayer(BootChatClient.Properties.Resources.ring);
                        s.Play();
                    }
                    firstload = true;
                }

                lastNumberOfInbox = lstInbox.Items.Count;
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

            int numOfMessages = 0;
            StringBuilder sb = new StringBuilder();
            foreach (Object row in (Object[])messages["messages"])
            {
                Dictionary<String, Object> message = (Dictionary<String, Object>)row;
                String from = Convert.ToString(message["from_user"]);
                String to = Convert.ToString(message["to_user"]);
                if (from == currentUser || to == currentUser)
                {
                    numOfMessages++;
                    sb.AppendLine(String.Format("{0}: {1}", message["from_user"], message["body"]));
                }
            }
            txtConvo.Text = sb.ToString();
            txtConvo.SelectionStart = txtConvo.Text.Length;
            txtConvo.ScrollToCaret();

            if (lastNumberOfMessages != numOfMessages)
            {
                if (lastNumberOfMessages > 0)
                {
                    SoundPlayer s = new SoundPlayer(BootChatClient.Properties.Resources.imrcv);
                    s.Play();
                }
                lastNumberOfMessages = numOfMessages;
            }
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

                    SoundPlayer play = new SoundPlayer(BootChatClient.Properties.Resources.imsend);
                    play.Play();
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
                lastNumberOfMessages = 0;
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



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                User32.ReleaseCapture();
                User32.SendMessage(Handle, User32.WM_NCLBUTTONDOWN, User32.HT_CAPTION, 0);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["FriendsListForm"] != null)
            {
                ((FriendsListForm)Application.OpenForms["FriendsListForm"]).Focus();
                ((FriendsListForm)Application.OpenForms["FriendsListForm"]).BringToFront();
                ((FriendsListForm)Application.OpenForms["FriendsListForm"]).WindowState = FormWindowState.Normal;
            }
            else
            {
                FriendsListForm f = new FriendsListForm();
                f.Show();
            }
        }

        private void btnGroupMessage_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["SendNewForm"] != null)
            {
                ((SendNewForm)Application.OpenForms["SendNewForm"]).Focus();
                ((SendNewForm)Application.OpenForms["SendNewForm"]).BringToFront();
                ((SendNewForm)Application.OpenForms["SendNewForm"]).WindowState = FormWindowState.Normal;
            }
            else
            {
                SendNewForm s = new SendNewForm();
                s.Show();
            }
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstInbox.SelectedIndex > -1)
            {
                ShowLoading(true);
                Dictionary<String, Object> result = Program.agent.deleteConvo(lstInbox.SelectedItem.ToString());
                Boolean success = Convert.ToBoolean(result["success"]);
                if (success)
                {
                    lstInbox.Items.RemoveAt(lstInbox.SelectedIndex);
                    txtConvo.Clear();
                    txtReply.Clear();
                    currentUser = String.Empty;
                    lastNumberOfMessages = 0;
                }
                else
                {
                    String exception = Convert.ToString(result["exception"]);
                    MessageBox.Show(exception);
                }
                ShowLoading(false);
            }
        }

        private void ShowLoading(Boolean show)
        {
            return;
            if (show)
            {
                panelWaiting.Location = new Point(0, 0);
                panelWaiting.Size = this.ClientSize;
                panelWaiting.Show();
            }
            else
            {
                panelWaiting.Hide();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loggingOut = true;
            tick = false;
            this.WindowState = FormWindowState.Minimized;
            System.Threading.Thread.Sleep(300);

            ((LoginForm)Application.OpenForms["LoginForm"]).Visible = true;
            ((LoginForm)Application.OpenForms["LoginForm"]).BringToFront();
            ((LoginForm)Application.OpenForms["LoginForm"]).Activate();
            ((LoginForm)Application.OpenForms["LoginForm"]).WindowState = FormWindowState.Normal;

            this.Close();
        }
    }
}
