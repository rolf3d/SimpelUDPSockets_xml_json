﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPReceiver_41_P
{
    class Program
    {
        private const int PORT = 7007;
        static void Main(string[] args)
        {
            UDPReceiver udpreciver = new UDPReceiver(PORT);
            udpreciver.Start();

            Console.ReadLine();
        }
    }
}
