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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.lstInbox);
            this.groupBox1.ForeColor = System.Drawing.Color.Lime;
            this.groupBox1.Location = new System.Drawing.Point(18, 49);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(189, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inbox";
            // 
            // lstInbox
            // 
            this.lstInbox.BackColor = System.Drawing.Color.Black;
            this.lstInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInbox.ForeColor = System.Drawing.Color.Lime;
            this.lstInbox.FormattingEnabled = true;
            this.lstInbox.ItemHeight = 26;
            this.lstInbox.Location = new System.Drawing.Point(6, 33);
            this.lstInbox.Name = "lstInbox";
            this.lstInbox.Size = new System.Drawing.Size(177, 257);
            this.lstInbox.TabIndex = 0;
            this.lstInbox.SelectedIndexChanged += new System.EventHandler(this.lstInbox_SelectedIndexChanged);
            // 
            // txtConvo
            // 
            this.txtConvo.BackColor = System.Drawing.Color.Black;
            this.txtConvo.ForeColor = System.Drawing.Color.Lime;
            this.txtConvo.Location = new System.Drawing.Point(216, 61);
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
            this.btnSend.BackColor = System.Drawing.Color.Black;
            this.btnSend.ForeColor = System.Drawing.Color.Lime;
            this.btnSend.Location = new System.Drawing.Point(627, 435);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 44);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReply
            // 
            this.txtReply.BackColor = System.Drawing.Color.Black;
            this.txtReply.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReply.ForeColor = System.Drawing.Color.Lime;
            this.txtReply.Location = new System.Drawing.Point(216, 445);
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(405, 28);
            this.txtReply.TabIndex = 3;
            // 
            // menuPanel
            // 
            this.menuPanel.BackgroundImage = global::BootChatClient.Properties.Resources.carbon;
            this.menuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuPanel.Controls.Add(this.btnMinimize);
            this.menuPanel.Controls.Add(this.btnExit);
            this.menuPanel.Location = new System.Drawing.Point(0, 1);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(760, 27);
            this.menuPanel.TabIndex = 4;
            this.menuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuPanel_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Yellow;
            this.btnMinimize.Location = new System.Drawing.Point(681, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 23);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(720, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ChatRoomInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(757, 494);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtConvo);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ChatRoomInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boot Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatRoomInterface_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatRoomInterface_FormClosed);
            this.Load += new System.EventHandler(this.ChatRoomInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstInbox;
        private System.Windows.Forms.TextBox txtConvo;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
    }
}