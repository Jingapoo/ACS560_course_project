namespace BootChatClient
{
    partial class ChatRoomInterface
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstInbox = new System.Windows.Forms.ListBox();
            this.txtConvo = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.btnCreateNew = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateNew);
            this.groupBox1.Controls.Add(this.lstInbox);
            this.groupBox1.Location = new System.Drawing.Point(26, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(189, 442);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inbox";
            // 
            // lstInbox
            // 
            this.lstInbox.FormattingEnabled = true;
            this.lstInbox.ItemHeight = 26;
            this.lstInbox.Location = new System.Drawing.Point(6, 33);
            this.lstInbox.Name = "lstInbox";
            this.lstInbox.Size = new System.Drawing.Size(177, 368);
            this.lstInbox.TabIndex = 0;
            this.lstInbox.SelectedIndexChanged += new System.EventHandler(this.lstInbox_SelectedIndexChanged);
            // 
            // txtConvo
            // 
            this.txtConvo.Location = new System.Drawing.Point(224, 27);
            this.txtConvo.Multiline = true;
            this.txtConvo.Name = "txtConvo";
            this.txtConvo.ReadOnly = true;
            this.txtConvo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConvo.Size = new System.Drawing.Size(518, 366);
            this.txtConvo.TabIndex = 1;
            this.txtConvo.TextChanged += new System.EventHandler(this.txtConvo_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(635, 401);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 44);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReply
            // 
            this.txtReply.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReply.Location = new System.Drawing.Point(224, 411);
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(405, 28);
            this.txtReply.TabIndex = 3;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.AutoSize = true;
            this.btnCreateNew.Location = new System.Drawing.Point(10, 408);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(115, 26);
            this.btnCreateNew.TabIndex = 1;
            this.btnCreateNew.TabStop = true;
            this.btnCreateNew.Text = "Create New";
            this.btnCreateNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCreateNew_LinkClicked);
            // 
            // ChatRoomInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(757, 472);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtConvo);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ChatRoomInterface";
            this.Text = "Boot Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatRoomInterface_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatRoomInterface_FormClosed);
            this.Load += new System.EventHandler(this.ChatRoomInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstInbox;
        private System.Windows.Forms.TextBox txtConvo;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.LinkLabel btnCreateNew;
    }
}