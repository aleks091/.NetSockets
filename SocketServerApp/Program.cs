﻿using SocketLibrary;
using System;
using System.Net.Sockets;
using System.Threading;

namespace SocketServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new SocketServer(ClientConnectedCallback, DataReceivedCallback);
            server.StartListening();

            Console.ReadKey();
        }

        public static void ClientConnectedCallback(Socket listener, Socket handler)
        {
            
        }

        public static object DataReceivedCallback(StateObject stateObject, Socket handler, object content)
        {
            Thread.Sleep(3000);

            if (content.ToString().Contains("GetDateTime"))
            {
                return GetDateTime();
            }
            else if(content.ToString().Contains("GetMessage"))
            {
                return GetMessage();
            }
            else
            {
                return "Method Not Found";
            }
        }

        public static DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public static string GetMessage()
        {
            return "Message from server";
        }
    }
}
