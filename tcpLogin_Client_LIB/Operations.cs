using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace tcpLogin_Client_LIB
{
    public class Operations
    {
        /// <summary>
        /// funkcja odpowiadająca za przesłanie prośby o logowanie do serwera
        /// </summary>
        /// <param name="stream">strumień połączenia </param>
        /// <param name="username">nazwa użytkownika</param>
        /// <param name="password">hasło użytkownika</param>
        /// <returns>informacja zwrotna od serwera</returns>
        public static StringBuilder Login(NetworkStream stream, string username, string password)
        {
            string dane = "1";
            Client.WriteToStream(stream, dane);
            Thread.Sleep(100);
            Client.WriteToStream(stream, username);
            Thread.Sleep(100);
            Client.WriteToStream(stream, password);
            return Client.ReadFromStream(stream);
            

        }

        /// <summary>
        /// funkcja odpowiadająca za przesłanie prośby o rejestracje do serwera
        /// </summary>
        /// <param name="stream">strumień połączenia z serwerem</param>
        /// <param name="username">nazwa użytkownika do rejestracji</param>
        /// <param name="password">hasło do rejestracji</param>
        /// <returns>informacja zwrotna od serwera</returns>
        public static StringBuilder Register(NetworkStream stream, string username, string password)
        {
            string dane = "2";
            Client.WriteToStream(stream, dane);
            Thread.Sleep(100);
            Client.WriteToStream(stream, username);
            Thread.Sleep(100);
            Client.WriteToStream(stream, password);
            return Client.ReadFromStream(stream);
        }

        /// <summary>
        /// Funkcja wysyłająca prośbę o wylogowanie użytkownika.
        /// </summary>
        /// <param name="stream">strumień połączenia z użytkownikiem</param>
        public static void Logout (NetworkStream stream)
        {
            string dane = "%logout%";
            Client.WriteToStream(stream, dane);
        }
    }
}
