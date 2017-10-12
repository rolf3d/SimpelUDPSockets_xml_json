using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPReceiver_41_P
{
    class UDPReceiver
    {

        private readonly int PORT;

        public UDPReceiver(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            
            // Receive
            byte[] buffer = new byte[2048];

            UdpClient udp = new UdpClient(PORT);
            IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Venter på at modtage: ");
            buffer = udp.Receive(ref senderEP);
            Console.WriteLine($"UDP datagram received lgt={buffer.Length}");
            Console.WriteLine($"Afsender er {senderEP.Address}, port {senderEP.Port}");

            // convert bytes to string
            String incommingStr = Encoding.ASCII.GetString(buffer);
            Console.WriteLine(incommingStr);



            //Send Back
            String outgoingStr = incommingStr.ToUpper();
            byte[] outBuffer = Encoding.ASCII.GetBytes(outgoingStr);

            udp.Send(outBuffer, outBuffer.Length, senderEP);
        }
    }
}
