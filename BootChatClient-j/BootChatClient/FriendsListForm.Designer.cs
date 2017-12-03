namespace BootChatClient
{
    partial class FriendsListForm
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.lstFriends = new System.Windows.Forms.ListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(176, 13);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(84, 142);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.Lime;
            this.btnAdd.Location = new System.Drawing.Point(176, 167);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 138);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.BackColor = System.Drawing.Color.Black;
            this.txtAdd.ForeColor = System.Drawing.Color.Lime;
            this.txtAdd.Location = new System.Drawing.Point(13, 318);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(247, 22);
            this.txtAdd.TabIndex = 3;
            this.txtAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstFriends
            // 
            this.lstFriends.BackColor = System.Drawing.Color.Black;
            this.lstFriends.ForeColor = System.Drawing.Color.Lime;
            this.lstFriends.FormattingEnabled = true;
            this.lstFriends.ItemHeight = 16;
            this.lstFriends.Location = new System.Drawing.Point(13, 13);
            this.lstFriends.Name = "lstFriends";
            this.lstFriends.Size = new System.Drawing.Size(157, 292);
            this.lstFriends.TabIndex = 4;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.ForeColor = System.Drawing.Color.PaleGreen;
            this.btnCopy.Location = new System.Drawing.Point(12, 368);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(247, 30);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy Selected";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FriendsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(272, 412);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lstFriends);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FriendsListForm";
            this.Text = "Friends List";
            this.Load += new System.EventHandler(this.FriendsListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.ListBox lstFriends;
        private System.Windows.Forms.Button btnCopy;
    }
}