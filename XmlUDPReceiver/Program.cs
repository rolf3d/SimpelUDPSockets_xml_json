using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlUDPReceiver
{
    class Program
    {
        private const int PORT = 7007;
        static void Main(string[] args)
        {
            UDPReceiver udpreceiverxml = new UDPReceiver(PORT);
            udpreceiverxml.Start();

            Console.ReadLine();
        }
    }
}
