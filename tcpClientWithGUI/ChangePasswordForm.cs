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
    public partial class ChangePasswordForm : Form
    {

        NetworkStream _stream;
        public ChangePasswordForm(NetworkStream stream)
        {
            _stream = stream; 
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (PasswordBox1.Text == PasswordBox2.Text)
            {
                Client.WriteToStream(_stream, "%change%");
                Client.WriteToStream(_stream, PasswordBox1.Text);
            }
            else
            {
                MessageBox.Show(" Passwords don't match !");
                return;
            }
        }
    }
}
