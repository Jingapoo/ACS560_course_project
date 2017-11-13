using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BootChatClient
{
    public partial class SendTo : Form
    {
        public SendTo()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Dictionary<String, Object> result = Program.agent.sendMessage(txtTo.Text, txtBody.Text);
            Boolean success = Convert.ToBoolean(result["success"]);

            if (success)
            {
                MessageBox.Show("Message Sent!");
            }
            else
            {
                MessageBox.Show("Error: " + Convert.ToString(result["exception"]));
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
