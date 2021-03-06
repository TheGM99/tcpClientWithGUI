﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tcpLogin_Client_LIB
{

   

    public class Client
    {
        
        int port;
        static int buffer_size = 1024;
        static bool running = false;
        static TcpClient tcpClient = new TcpClient();
        IPAddress iPAddress;

        static NetworkStream stream;
        public Client()
        {                            
                     
        }
 
        public static NetworkStream Stream { get => stream;}

        public static TcpClient TcpClient { get => tcpClient; }

        /// <summary>
        /// funkcja wysylania wiadomosci do serwera
        /// </summary>
        /// <param name="stream">strumień połączenia z serwerem</param>
        /// <param name="dane"> przesyłane dane</param>
        public static void WriteToStream(NetworkStream stream, string dane)
        {
            byte[] writebuffer = new byte[Buffer_size];
            writebuffer = Encoding.ASCII.GetBytes(dane);
            stream.Write(writebuffer, 0, writebuffer.Length);
        }

        /// <summary>
        /// funkcja odbierania informacji z serwera
        /// </summary>
        /// <param name="stream">strumień połączenia z serwerem</param>
        /// <returns>pobrane dane</returns>
        public static StringBuilder ReadFromStream(NetworkStream stream)
        {
            StringBuilder readable = new StringBuilder();
            byte[] readbuffer = new byte[Buffer_size];
            do
            {
                int message_size = stream.Read(readbuffer, 0, readbuffer.Length);
                readable.Append(Encoding.ASCII.GetString(readbuffer, 0, message_size));
            } while (stream.DataAvailable);

            return readable;

        }

        /// <summary>
        /// funkcja nawiązująca połączenie z serwerem
        /// </summary>
        /// <param name="IP">adres ip serwera</param>
        /// <param name="port">port</param>
        public static void connect(IPAddress IP, int port)
        {
            IPEndPoint temp = new IPEndPoint(IP,port);
            tcpClient.Connect(temp);
            stream = tcpClient.GetStream();
        }
        public static int Buffer_size
        {
            get => buffer_size; set

            {

                if (value < 0 || value > 1024 * 1024 * 64) throw new Exception("błędny rozmiar pakietu");

                if (!running) buffer_size = value; else throw new Exception("nie można zmienić rozmiaru pakietu kiedy serwer jest uruchomiony");

            }

        }


        public IPAddress IPAddress { get => iPAddress; set { if (!running) iPAddress = value; else throw new Exception("nie można zmienić adresu IP kiedy serwer jest uruchomiony"); } }

        /// <summary>
        /// This property gives access to the port of a server instance. Property can't be changed when the Server is running. Setting invalid port numbers will cause an exception. 
        /// </summary>

        public int Port
        {
            get => port;
       }

    }
}
