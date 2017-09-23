namespace BootChatClient
{
    partial class CreateNewUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.maskPassword = new System.Windows.Forms.MaskedTextBox();
            this.maskConfirm = new System.Windows.Forms.MaskedTextBox();
            this.txtSecureQue = new System.Windows.Forms.TextBox();
            this.txtSecureAns = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.errPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.errUsername = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUsername)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUser.Location = new System.Drawing.Point(80, 27);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(164, 26);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "Username";
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            // 
            // maskPassword
            // 
            this.maskPassword.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskPassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.maskPassword.Location = new System.Drawing.Point(80, 70);
            this.maskPassword.Name = "maskPassword";
            this.maskPassword.Size = new System.Drawing.Size(164, 26);
            this.maskPassword.TabIndex = 2;
            this.maskPassword.Text = "Password";
            this.maskPassword.Enter += new System.EventHandler(this.maskPassword_Enter);
            // 
            // maskConfirm
            // 
            this.maskConfirm.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskConfirm.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.maskConfirm.Location = new System.Drawing.Point(80, 116);
            this.maskConfirm.Name = "maskConfirm";
            this.maskConfirm.Size = new System.Drawing.Size(164, 26);
            this.maskConfirm.TabIndex = 3;
            this.maskConfirm.Text = "Confirm Password";
            this.maskConfirm.TextChanged += new System.EventHandler(this.maskConfirm_TextChanged);
            this.maskConfirm.Enter += new System.EventHandler(this.maskConfirm_Enter);
            this.maskConfirm.Leave += new System.EventHandler(this.maskConfirm_Leave);
            // 
            // txtSecureQue
            // 
            this.txtSecureQue.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecureQue.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSecureQue.Location = new System.Drawing.Point(31, 163);
            this.txtSecureQue.Name = "txtSecureQue";
            this.txtSecureQue.Size = new System.Drawing.Size(265, 26);
            this.txtSecureQue.TabIndex = 4;
            this.txtSecureQue.Text = "Enter your security question";
            this.txtSecureQue.Enter += new System.EventHandler(this.txtSecureQue_Enter);
            // 
            // txtSecureAns
            // 
            this.txtSecureAns.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecureAns.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSecureAns.Location = new System.Drawing.Point(31, 205);
            this.txtSecureAns.Name = "txtSecureAns";
            this.txtSecureAns.Size = new System.Drawing.Size(265, 26);
            this.txtSecureAns.TabIndex = 5;
            this.txtSecureAns.Text = "Enter your security answer";
            this.txtSecureAns.Enter += new System.EventHandler(this.txtSecureAns_Enter);
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.Black;
            this.btnContinue.Location = new System.Drawing.Point(221, 252);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 37);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(31, 252);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(69, 37);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // errPassword
            // 
            this.errPassword.ContainerControl = this;
            // 
            // errUsername
            // 
            this.errUsername.ContainerControl = this;
            // 
            // CreateNewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(331, 301);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtSecureAns);
            this.Controls.Add(this.txtSecureQue);
            this.Controls.Add(this.maskConfirm);
            this.Controls.Add(this.maskPassword);
            this.Controls.Add(this.txtUser);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Name = "CreateNewUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a new account";
            ((System.ComponentModel.ISupportInitialize)(this.errPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUsername)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.MaskedTextBox maskPassword;
        private System.Windows.Forms.MaskedTextBox maskConfirm;
        private System.Windows.Forms.TextBox txtSecureQue;
        private System.Windows.Forms.TextBox txtSecureAns;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ErrorProvider errPassword;
        private System.Windows.Forms.ErrorProvider errUsername;
    }
}