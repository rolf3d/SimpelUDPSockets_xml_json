using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonUDPSender
{
    public class Client
    {
        private readonly int PORT;

        public Client(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            Car bil01 = new Car("Tesla", "red", "EL23400");

            
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            UdpClient udp = new UdpClient();

            String sendjsonbil = JsonConvert.SerializeObject(bil01);
            
            byte[] databuffer = Encoding.ASCII.GetBytes(sendjsonbil);

            while (true)
            {
                udp.Send(databuffer, databuffer.Length, endPoint);

                Console.WriteLine($"UDP datagram sendt lgt={sendjsonbil.Length}");
                Console.WriteLine();
                Console.WriteLine("Sendt objekt: " + sendjsonbil);
                System.Threading.Thread.Sleep(1500);
            }


            

        }
    }
}
