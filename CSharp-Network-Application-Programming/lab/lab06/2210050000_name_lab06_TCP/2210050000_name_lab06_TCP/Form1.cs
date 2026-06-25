using _2210050000_name_lab06_TCP;
using System;
using System.Windows.Forms;

namespace _2210050000_name_lab06_TCP
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = "???";
        }

        private void btnStartTwoClients_Click(object sender, EventArgs e)
        {
            ClientChatWindow client1 = new ClientChatWindow();
            client1.Show();

            ClientChatWindow client2 = new ClientChatWindow();
            client2.Show();
        }

        private void btnStartOneClient_Click(object sender, EventArgs e)
        {
            ClientChatWindow client = new ClientChatWindow();
            client.Show();
        }
    }
}