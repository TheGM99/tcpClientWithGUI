using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tcpLogin_Client_LIB;

namespace tcpClientWithGUI
{

    //TODO
    //MAhe ChatLog Work
    public partial class FuncForm : Form
    {
        Form otherform;
        NetworkStream _stream;
        String[] ActiveUsers;
        String CurrentUser;
        String User;
       // Dictionary<String, String> ChatLog = new Dictionary<string, string>(); WIP
        Task listening;
        bool running = true;

        public FuncForm(Form form, NetworkStream stream, String Login)
        {
            InitializeComponent();
            otherform = form;
            _stream = stream;
            ActiveUsers = Client.ReadFromStream(stream).ToString().Split(new char[] {','});
            ActiveUsersBox.Items.AddRange(ActiveUsers);
           // UpdateLogsUsers();
            listening = Task.Run(() => Listener());
            UserLabel.Text = Login;
            User = Login;
        }

        /// <summary>
        /// Funkcja dla przycisku "Do Nothing"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Operations.Logout(_stream);
            running = false;
            otherform.Show();
        }


        private void textSender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Client.WriteToStream(_stream,CurrentUser + "% " + textSender.Text);
                String temp = MessBox.Text;
                temp +=  User + ": " + textSender.Text + "\r\n";
                MessBox.Text = temp;
              //  ChatLog[CurrentUser] = temp;
                textSender.Clear();
            }
        }

       /* private void UpdateLogsUsers()
        {
            foreach(String user in ActiveUsers)
            {
                if (!ChatLog.ContainsKey(user))
                    ChatLog.Add(user, "");
            }
        }*/
        private void Listener()
        {           
            while (running)
            {
                String Message = Client.ReadFromStream(_stream).ToString();
                switch (Message)
                {
                    case "%lista%":
                        ActiveUsers = Client.ReadFromStream(_stream).ToString().Split(new char[] { ',' });
                        ActiveUsersBox.Items.Clear();
                        ActiveUsersBox.Items.AddRange(ActiveUsers);
                      //  UpdateLogsUsers();
                        break;
                    case "1":
                        MessageBox.Show("Change was succesful.");
                        break;
                    case "0":
                        MessageBox.Show("Change was unsuccesful.");
                        break;
                    default:
                        String[] splitter = Message.Split(new char[] { '%' });
                        String temp = MessBox.Text;
                        Message = Message.Replace('%', ':');
                        temp += Message + "\r\n";
                       // ChatLog[splitter[0]] += temp;                     
                        if(CurrentUser == splitter[0])
                        MessBox.Text = temp;
                        break;
                }
            }
        }

        private void ActiveUsersBox_Click(object sender, EventArgs e)
        {
            var test = Array.Find(ActiveUsers, ele => ele == ActiveUsersBox.SelectedItem.ToString());
            if (test != null)
            {
                MessBox.Clear();
                //MessageBox.Text = ChatLog[ActiveUsersBox.SelectedItem.ToString()];
                CurrentUser = ActiveUsersBox.SelectedItem.ToString();
            }
          
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Client.WriteToStream(_stream, "%refresh%");
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            ChangePasswordForm CPF = new ChangePasswordForm(_stream);
            CPF.Show();           
        }
    }
}
