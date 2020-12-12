using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tcpLogin_Client_LIB;

namespace tcpClientWithGUI
{
    public partial class LoginForm : Form
    {

        private NetworkStream _stream;

        public LoginForm(NetworkStream stream)
        {
            _stream = stream;
            InitializeComponent();
        }

        /// <summary>
        /// funkcja logowania uruchamiająca się po naciśnięciu odpowiedniego przycisku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, EventArgs e)
        {

            StringBuilder readable = Operations.Login(_stream, userTextBox.Text, passTextBox.Text);
            if (readable[0] == '1')
            {
                MessageBox.Show("Login Succesful.");
                this.Hide();
                FuncForm ff = new FuncForm(this, _stream, userTextBox.Text);
                ff.Show();

            }
            else if (readable[0] == '2')
            {
                MessageBox.Show(" Someone is already logged in");
            }
            else { MessageBox.Show("Wrong username or password.");}
        }

        /// <summary>
        /// funkcja rejestracji uruchamiająca się po naciśnięciu odpowiedniego przycisku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, EventArgs e)
        {
            StringBuilder readable = Operations.Register(_stream, userTextBox.Text, passTextBox.Text);
            if (readable[0] == '1')
            {
                MessageBox.Show("Registration Succesful. You can now login.");
            }
            else MessageBox.Show("This user already exists!");
        }
      
    }
}
