using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlUDPSender
{
    class Program
    {
        private const int PORT = 7007;
        static void Main(string[] args)
        {
            UDPSender udpsenderxml = new UDPSender(PORT);
            udpsenderxml.Start();

            Console.ReadLine();
        }
    }
}
