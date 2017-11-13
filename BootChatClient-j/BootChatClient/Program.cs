using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BootChatClient
{
    static class Program
    {

        public static BootChatHttpAgent agent = new BootChatHttpAgent("https://sandbox-jpsimos.c9users.io");
        public static LocalDatabase localdb = new LocalDatabase();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        public static void Exit()
        {
            localdb.close();
            Application.Exit();
        }
    }
}
