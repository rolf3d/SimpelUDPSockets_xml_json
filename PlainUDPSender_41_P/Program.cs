using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPSender_41_P
{
    class Program
    {
        private const int PORT = 7007;
        static void Main(string[] args)
        {
            UDPSender udpsender = new UDPSender(PORT);
            udpsender.Start();

            Console.ReadLine();
        }
    }
}
