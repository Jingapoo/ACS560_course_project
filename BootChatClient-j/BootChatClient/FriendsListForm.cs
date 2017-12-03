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
    public partial class FriendsListForm : Form
    {
        public FriendsListForm()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            List<String> friends = Program.localdb.getFriendsList(Program.agent.getUsername());
            lstFriends.Items.Clear();
            foreach(String friend in friends)
            {
                lstFriends.Items.Add(friend);
            }
        }

        private void FriendsListForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lstFriends.SelectedIndex > -1)
            {
                String rmFriend = lstFriends.SelectedItem.ToString();
                Program.localdb.removeFriendFromList(Program.agent.getUsername(), rmFriend);
                RefreshList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtAdd.Text.Length < 1)
            {
                MessageBox.Show("Type a username in the box below then press Add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if(!lstFriends.Items.Contains(txtAdd.Text))
            {
                Program.localdb.addFriendToList(Program.agent.getUsername(), txtAdd.Text);
                RefreshList();
                txtAdd.Clear();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lstFriends.SelectedIndex > -1)
            {
                Clipboard.SetText(lstFriends.SelectedItem.ToString());
                MessageBox.Show(String.Format("Copied {0} to the clipboard.", lstFriends.SelectedItem.ToString()));
            }
        }
    }
}
