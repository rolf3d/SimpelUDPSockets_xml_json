using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUDPReceiver
{
    class Program
    {
        private const int PORT = 7007;
        static void Main(string[] args)
        {
            UDPReceiver udpreceiver = new UDPReceiver(PORT);
            udpreceiver.Start();

            Console.ReadLine();
        }
    }
}
