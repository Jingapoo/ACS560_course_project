namespace BootchatRoom
{
    partial class chatroominterface
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
            this.btnchat = new System.Windows.Forms.Button();
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.listBoxContact = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnchat
            // 
            this.btnchat.Location = new System.Drawing.Point(55, 12);
            this.btnchat.Name = "btnchat";
            this.btnchat.Size = new System.Drawing.Size(75, 23);
            this.btnchat.TabIndex = 0;
            this.btnchat.Text = "chat";
            this.btnchat.UseVisualStyleBackColor = true;
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Location = new System.Drawing.Point(243, 12);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(75, 23);
            this.btnAddFriend.TabIndex = 1;
            this.btnAddFriend.Text = "Add Friend";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            // 
            // listBoxContact
            // 
            this.listBoxContact.FormattingEnabled = true;
            this.listBoxContact.Location = new System.Drawing.Point(24, 70);
            this.listBoxContact.Name = "listBoxContact";
            this.listBoxContact.ScrollAlwaysVisible = true;
            this.listBoxContact.Size = new System.Drawing.Size(120, 290);
            this.listBoxContact.TabIndex = 2;
            // 
            // chatroominterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 449);
            this.Controls.Add(this.listBoxContact);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.btnchat);
            this.Name = "chatroominterface";
            this.Text = "chatroominterface";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnchat;
        private System.Windows.Forms.Button btnAddFriend;
        private System.Windows.Forms.ListBox listBoxContact;
    }
}