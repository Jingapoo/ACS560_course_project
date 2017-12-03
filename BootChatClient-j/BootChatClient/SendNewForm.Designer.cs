namespace BootChatClient
{
    partial class SendNewForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstRecepients = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.btnFriends = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipients:";
            // 
            // lstRecepients
            // 
            this.lstRecepients.BackColor = System.Drawing.Color.Black;
            this.lstRecepients.ForeColor = System.Drawing.Color.Lime;
            this.lstRecepients.FormattingEnabled = true;
            this.lstRecepients.ItemHeight = 18;
            this.lstRecepients.Location = new System.Drawing.Point(16, 34);
            this.lstRecepients.Name = "lstRecepients";
            this.lstRecepients.Size = new System.Drawing.Size(120, 148);
            this.lstRecepients.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(142, 126);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 56);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(142, 34);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(83, 32);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.BackColor = System.Drawing.Color.Black;
            this.txtAdd.ForeColor = System.Drawing.Color.Lime;
            this.txtAdd.Location = new System.Drawing.Point(16, 189);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(209, 24);
            this.txtAdd.TabIndex = 4;
            this.txtAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFriends
            // 
            this.btnFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFriends.ForeColor = System.Drawing.Color.Yellow;
            this.btnFriends.Location = new System.Drawing.Point(142, 72);
            this.btnFriends.Name = "btnFriends";
            this.btnFriends.Size = new System.Drawing.Size(83, 48);
            this.btnFriends.TabIndex = 5;
            this.btnFriends.Text = "Friends";
            this.btnFriends.UseVisualStyleBackColor = true;
            this.btnFriends.Click += new System.EventHandler(this.btnFriends_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.txtBody);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(235, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 179);
            this.panel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Tomato;
            this.btnCancel.Location = new System.Drawing.Point(305, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSend
            // 
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSend.Location = new System.Drawing.Point(13, 102);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(283, 32);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtBody
            // 
            this.txtBody.BackColor = System.Drawing.Color.Black;
            this.txtBody.ForeColor = System.Drawing.Color.Lime;
            this.txtBody.Location = new System.Drawing.Point(13, 60);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(375, 24);
            this.txtBody.TabIndex = 7;
            this.txtBody.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Message Body:";
            // 
            // SendNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(652, 226);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFriends);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstRecepients);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendNewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send New";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstRecepients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Button btnFriends;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label2;
    }
}