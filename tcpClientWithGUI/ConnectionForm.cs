using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tcpLogin_Client_LIB;

using System.Net;

namespace tcpClientWithGUI
{
    public partial class ConnectionForm : Form
    {
        private Client _client;
        public ConnectionForm(Client client )
        {
            _client = client;
            InitializeComponent();
        }

        /// <summary>
        /// funkcja nawiązująca połączenie, uruchamiająca się po naciśnięciu odpowiedniego przycisku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_Click(object sender, EventArgs e)
        {
            try
            {
                Client.connect(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text));
                this.Hide();
                LoginForm lf = new LoginForm(Client.Stream);
                lf.Show();
            }
            catch (Exception er) { Console.WriteLine(er); }
        }
    }
}
