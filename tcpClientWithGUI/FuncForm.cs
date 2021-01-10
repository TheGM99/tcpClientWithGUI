﻿using System;
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
        Dictionary<String, String> ChatLog = new Dictionary<string, string>(); //WIP
        Task listening;
        bool running = true;

        public FuncForm(Form form, NetworkStream stream, String Login)
        {
            InitializeComponent();
            otherform = form;
            _stream = stream;
            ActiveUsers = Client.ReadFromStream(stream).ToString().Split(new char[] {','});
            ActiveUsersBox.Items.AddRange(ActiveUsers);
            UpdateLogsUsers();
            listening = Task.Run(() => Listener());
            UserLabel.Text = Login;
            User = Login;
        }


        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Operations.Logout(_stream);
            running = false;
            otherform.Show();
        }


        private void textSender_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter && ActiveUsersBox.SelectedItem != null)
            {
                Client.WriteToStream(_stream,CurrentUser + "% " + textSender.Text);
                String temp = MessBox.Text;
                temp +=  User + ": " + textSender.Text + "\r\n";
                MessBox.Text = temp;
                ChatLog[CurrentUser] = MessBox.Text;
                textSender.Clear();
            }
        }
        
        /// <summary>
        /// Funkcja aktualizujaca ChatLog o nowych użytkowników, którzy dołączyli do Chatu.
        /// </summary>
        private void UpdateLogsUsers()
        {
            foreach(String user in ActiveUsers)
            {
                if (!ChatLog.ContainsKey(user))
                    ChatLog.Add(user, "");
            }
        }

        /// <summary>
        /// Funkcja odpowiedzialna za odbieranie komunikatów od serwera
        /// </summary>
        private void Listener()
        {           
            while (running)
            {
                String Message = Client.ReadFromStream(_stream).ToString();
                switch (Message)
                {
                    case "%lista%":
                        if (ActiveUsersBox.InvokeRequired)
                        {
                            ActiveUsers = Client.ReadFromStream(_stream).ToString().Split(new char[] { ',' });
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ActiveUsersBox.Items.Clear();
                                ActiveUsersBox.Items.AddRange(ActiveUsers);
                            }));
                        }
                            UpdateLogsUsers();
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
                            ChatLog[splitter[0]] += temp;
                        if (CurrentUser == splitter[0])
                            if (MessBox.InvokeRequired)
                                this.Invoke(new MethodInvoker(delegate ()
                            {
                                MessBox.Text = temp;
                            }));
                        break;
                }
            }
        }

        /// <summary>
        /// Funkcja ustawiająca uźytkownika do którego aktualnie piszemy i wczytująca popszednie wiadomości
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveUsersBox_Click(object sender, EventArgs e)
        {
            if (ActiveUsersBox.SelectedItem != null)
            {
                var test = Array.Find(ActiveUsers, ele => ele == ActiveUsersBox.SelectedItem.ToString());
                if (!String.IsNullOrEmpty(test))
                {
                    MessBox.Clear();
                    MessBox.Text = ChatLog[ActiveUsersBox.SelectedItem.ToString()];
                    CurrentUser = ActiveUsersBox.SelectedItem.ToString();
                }
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
