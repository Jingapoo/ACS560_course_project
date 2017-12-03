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
    public partial class SendNewForm : Form
    {
        public SendNewForm()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lstRecepients.SelectedIndex > -1)
            {
                lstRecepients.Items.RemoveAt(lstRecepients.SelectedIndex);
            }
        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FriendsListForm"] != null)
            {
                ((FriendsListForm)Application.OpenForms["FriendsListForm"]).Focus();
                ((FriendsListForm)Application.OpenForms["FriendsListForm"]).BringToFront();
            }
            else
            {
                FriendsListForm f = new FriendsListForm();
                f.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtAdd.Text.Length > 1)
            {
                if (!lstRecepients.Items.Contains(txtAdd.Text))
                {
                    lstRecepients.Items.Add(txtAdd.Text);
                    txtAdd.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter a receipient in the box below, then press Add again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(lstRecepients.Items.Count < 1)
            {
                MessageBox.Show("You must have at least one receipient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Boolean waserror = false;
            foreach (String receiv in lstRecepients.Items)
            {
                Dictionary<String, object> result = Program.agent.sendMessage(receiv, txtBody.Text);
                Boolean success = Convert.ToBoolean(result["success"]);
                if (!success)
                {
                    String exception = Convert.ToString(result["exception"]);
                    MessageBox.Show("Error: " + exception);
                    waserror = true;
                    break;
                }
            }

            if (!waserror)
            {
                this.WindowState = FormWindowState.Minimized;
                System.Threading.Thread.Sleep(500);
                MessageBox.Show("Successfully sent message to " + lstRecepients.Items.Count.ToString() + " receipients.");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
