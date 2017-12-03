using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BootChatClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm newForgotPasswordForm = new ForgotPasswordForm();
            DialogResult userPressed = newForgotPasswordForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (chkRememberMe.Checked)
            {
                Program.localdb.updateValue("saved_user", txtUsername.Text);
                Program.localdb.updateValue("saved_pass", txtPassword.Text);
            }
            else
            {
                Program.localdb.unsetValue("saved_user");
                Program.localdb.unsetValue("saved_pass");
            }

            if(Program.agent.login(txtUsername.Text, txtPassword.Text)){
                //MessageBox.Show("Welcome, " + Program.agent.getNickname());
                ChatRoomInterface ci = new ChatRoomInterface();
                ci.Show();
                this.Visible = false;
            }else{
                MessageBox.Show("Could not log in.");
            }

            //String savedUser = Program.localdb.getValue("saved_user");
            //String savedPass = Program.localdb.getValue("saved_pass");
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnCreateNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateNewUserForm newUserForm = new CreateNewUserForm();
            newUserForm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Program.localdb.keyExists("saved_user") && Program.localdb.keyExists("saved_pass"))
            {
                String savedUser = Program.localdb.getValue("saved_user");
                String savedPass = Program.localdb.getValue("saved_pass");
                if (savedUser != null && savedPass != null)
                {
                    if (savedUser.Length > 0 && savedPass.Length > 0)
                    {
                        txtUsername_Enter(null, null);
                        txtPassword_Enter(null, null);
                        txtUsername.Text = savedUser;
                        txtPassword.Text = savedPass;
                        chkRememberMe.Checked = true;
                    }
                }
            }
            else
            {
                Program.localdb.insertValue("saved_user", String.Empty);
                Program.localdb.insertValue("saved_pass", String.Empty);
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                User32.ReleaseCapture();
                User32.SendMessage(Handle, User32.WM_NCLBUTTONDOWN, User32.HT_CAPTION, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
