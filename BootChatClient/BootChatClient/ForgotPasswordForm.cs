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
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            BootChatHttpAgent agent = new BootChatHttpAgent();
            NameValueCollection postData = new NameValueCollection();

            postData.Add("request", "forgot");
            postData.Add("username", txtUsername.Text);
            postData.Add("question", txtQuestion.Text);
            postData.Add("answer", txtAnswer.Text);
            postData.Add("password", txtNewPassword.Text);

            Dictionary<String, Object> result = agent.doHttpPost("http://localhost", postData);
            bool wasSuccess = (bool)result["success"];

            if (!wasSuccess)
            {
                MessageBox.Show((string)result["exception"]);
            }
            else
            {
                MessageBox.Show("Success! Your password has been changed");
                this.DialogResult = DialogResult.OK;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
