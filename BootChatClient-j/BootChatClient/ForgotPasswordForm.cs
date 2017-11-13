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

            BootChatHttpAgent agent = new BootChatHttpAgent("https://sandbox-jpsimos.c9users.io");
          
            //...


            this.DialogResult = DialogResult.OK;
            this.Close();
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

            if(txtConfirmPassword.Text != txtNewPassword.Text){
                if (showNew){
                    errPassword.SetError(txtConfirmPassword, "Passwords do not match");
                }
                result = false;
            }else{
                errPassword.SetError(txtConfirmPassword, null);
            }

            return result;
        }
    }
}
