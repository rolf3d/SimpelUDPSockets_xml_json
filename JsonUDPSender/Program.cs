using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUDPSender
{
    class Program
    {
        private const int PORt = 7007;
        static void Main(string[] args)
        {
            Client jsonclient = new Client(PORt);
            jsonclient.Start();

            Console.ReadLine();
        }
    }
}
