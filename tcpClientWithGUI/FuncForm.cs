using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tcpClientWithGUI
{
    public partial class FuncForm : Form
    {
        Form otherform;
        public FuncForm(Form form)
        {
            InitializeComponent();
            otherform = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nothing was done.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            otherform.Show();
        }
    }
}
