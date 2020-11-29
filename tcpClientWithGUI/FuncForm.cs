using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using tcpLogin_Client_LIB;

namespace tcpClientWithGUI
{
    public partial class FuncForm : Form
    {
        Form otherform;
        NetworkStream _stream;
        public FuncForm(Form form, NetworkStream stream)
        {
            InitializeComponent();
            otherform = form;
            _stream = stream;
        }

        /// <summary>
        /// Funkcja dla przycisku "Do Nothing"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nothing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nothing was done.");
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Operations.Logout(_stream);
            otherform.Show();
        }
    }
}
