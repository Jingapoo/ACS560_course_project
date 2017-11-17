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

            if (!checkForErrors(true))
            {
                return;
            }

            Dictionary<String,Object> result = Program.agent.forgotPasswordRequest(txtUsername.Text, txtQuestion.Text, txtAnswer.Text, txtNewPassword.Text);
            Program.agent.DebugPrintDictionary(result);
        }

        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool checkForErrors(bool showNew)
        {
            Boolean result = true;
            if(txtUsername.Text.Length == 0)
            {
                if (showNew)
                {
                    errUsername.SetError(txtUsername, "Enter your username.");
                }
                result = false;
            }
            else
            {
                errUsername.SetError(txtUsername, null);
            }

            if(txtConfirmPassword.Text != txtNewPassword.Text || txtNewPassword.Text.Length < 1 || txtConfirmPassword.Text.Length < 1){
                if (showNew){
                    errPassword.SetError(txtConfirmPassword, "Passwords do not match");
                }
                result = false;
            }else{
                errPassword.SetError(txtConfirmPassword, null);
            }

            if(txtAnswer.Text.Length < 1 || txtQuestion.Text.Length < 1)
            {
                if (showNew){
                    errQuestion.SetError(txtQuestion, "Must provide a security question and answer.");
                }
                result = false;
            }else{
                errQuestion.SetError(txtQuestion, null);
            }

            return result;
        }
    }
}
