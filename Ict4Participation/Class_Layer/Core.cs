//-----------------------------------------------------------------------
// <copyright file="Core.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer
{
    /// <summary>
    /// The core class of the chat application
    /// </summary>
    public class Core
    {
        private Socket socket { get; set; }
        private EndPoint epClient1;
        private EndPoint epClient2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Core"/> class.
        /// </summary>
        public Core()
        {
            // Create new socket
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Set socket options
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        /// <summary>
        /// Connect to a user
        /// </summary>
        public void Connect(string ip1, string ip2, int port1, int port2)
        {
            string error = string.Empty;

            try
            {
                epClient1 = new IPEndPoint(IPAddress.Parse(ip1), port1);
                epClient2 = new IPEndPoint(IPAddress.Parse(ip2), port2);

                // Bind socket endpoint1
                socket.Bind(epClient1);
                // Connect with endpoint2
                socket.Connect(epClient2);

                // Buffer for receiving messages, 1500 bytes long
                byte[] buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epClient2, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            string error = string.Empty;

            try
            {
                int size = socket.EndReceiveFrom(aResult, ref epClient2);

                if (size > 0)
                {
                    byte[] receivedData = new byte[1500];

                    receivedData = (byte[])aResult.AsyncState;

                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);

                    // return message to GUI
                }

                byte[] buffer = new byte[1500];

                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epClient1, new AsyncCallback(MessageCallBack), buffer);
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
        }

        /// <summary>
        /// Send a message to the user
        /// </summary>
        public void SendMessage()
        {
            string error = string.Empty;

            try
            {
                ASCIIEncoding enc = new ASCIIEncoding();
                // A message is 1500 bytes long
                byte[] msg = new byte[1500];

                socket.Send(msg);
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
        }

        /// <summary>
        /// Receive a message
        /// </summary>
        public void ReceiveMessage()
        {
            // implement
        }

        /// <summary>
        /// Delete a message
        /// </summary>
        public void DeleteMessage()
        {
            // implement
        }

        /// <summary>
        /// Logs chat
        /// </summary>
        public void LogChat()
        {
            // implement
        }

        /// <summary>
        /// Disconnect from user
        /// </summary>
        public void Disconnect()
        {
            // implement
        }
    }
}
