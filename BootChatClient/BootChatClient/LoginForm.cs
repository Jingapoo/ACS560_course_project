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
            BootChatHttpAgent agent = new BootChatHttpAgent();
            NameValueCollection postData = new NameValueCollection();

            postData.Add("request", "login");
            postData.Add("username", txtUsername.Text);
            postData.Add("password", txtPassword.Text);

            Dictionary<String, Object> result = agent.doHttpPost("http://localhost", postData);

            bool wasSuccess = (bool)result["success"];
            if (wasSuccess){
                MessageBox.Show("Welcome, " + txtUsername.Text, "Success");
            } else {
                string exceptionMessage = (string)result["exception"];
                MessageBox.Show(exceptionMessage, "Error");
            }

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
            DialogResult userClicked = newUserForm.ShowDialog();
            if(userClicked == DialogResult.OK)
            {
                //do something.
            }
        }
    }
}
