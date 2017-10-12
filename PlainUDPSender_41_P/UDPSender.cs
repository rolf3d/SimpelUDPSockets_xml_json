using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace PlainUDPSender_41_P
{
    public class UDPSender
    {
        private readonly int PORT;

        public UDPSender(int port)
        {
            PORT = port;
        }
        public void Start()
        {
            Car bil01 = new Car("Tesla","red","EL23400");
            // Laver bil objektet om til ren tekst.
            var tekstbil = bil01.ToString();
            // Sender
           
            //String SenderStr = "peter";
            byte[] buffer = Encoding.ASCII.GetBytes(tekstbil);

            UdpClient udp = new UdpClient();

            IPEndPoint OtherEP = new IPEndPoint(IPAddress.Broadcast, PORT);
            udp.Send(buffer, buffer.Length, OtherEP);


            IPEndPoint ReceicerEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] receivebuffer = udp.Receive(ref ReceicerEP);
            Console.WriteLine($"UDP datagram received lgt={receivebuffer.Length}");
            String incommingStr = Encoding.ASCII.GetString(receivebuffer);
            Console.WriteLine(incommingStr);

        }
    }
}
