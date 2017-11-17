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
    public partial class CreateNewUserForm : Form
    {
        public CreateNewUserForm()
        {
            InitializeComponent();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "Username")
            {
                txtUser.Clear();
                txtUser.ForeColor = Color.LightGreen;
            }
        }

        private void maskConfirm_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!checkPasswordMatch(false))
            {
                return;
            }

            

            //...
        }

        private bool checkPasswordMatch(bool clearErrorOnly)
        {
            Boolean result = true;

            if(txtUser.Text.Length == 0)
            {
                if (!clearErrorOnly)
                {
                    errUsername.SetError(txtUser, "Enter your desired username.");
                }
                result = false;
            }
            else
            {
                errUsername.SetError(txtUser, null);
            }

            if(maskPassword.Text != maskConfirm.Text)
            {
                if (!clearErrorOnly)
                {
                    errPassword.SetError(maskConfirm, "Passwords do not match.");
                }
                result = false;
            }else{
                errPassword.SetError(maskConfirm, null);
            }

            return result;
        }

        private void maskConfirm_Leave(object sender, EventArgs e)
        {
            checkPasswordMatch(false);
        }

        private void maskPassword_Enter(object sender, EventArgs e)
        {
            if (maskPassword.Text == "Password")
            {
                maskPassword.Clear();
                maskPassword.ForeColor = Color.LightGreen;
                maskPassword.UseSystemPasswordChar = true;
            }
        }

        private void maskConfirm_Enter(object sender, EventArgs e)
        {
            if(maskConfirm.Text == "Confirm Password")
            {
                maskConfirm.Clear();
                maskConfirm.ForeColor = Color.LightGreen;
                maskConfirm.UseSystemPasswordChar = true;
            }
        }

        private void maskConfirm_TextChanged(object sender, EventArgs e)
        {
            checkPasswordMatch(true);
        }

        private void txtSecureQue_Enter(object sender, EventArgs e)
        {
            if(txtSecureQue.Text == "Enter your security question")
            {
                txtSecureQue.Clear();
                txtSecureQue.ForeColor = Color.LightGreen;  
            }
        }

        private void txtSecureAns_Enter(object sender, EventArgs e)
        {
            if(txtSecureAns.Text == "Enter your security answer")
            {
                txtSecureAns.Clear();
                txtSecureAns.ForeColor = Color.LightGreen;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CreateNewUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
