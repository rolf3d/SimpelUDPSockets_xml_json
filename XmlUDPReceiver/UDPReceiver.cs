using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModelLib;

namespace XmlUDPReceiver
{
    public class UDPReceiver
    {
        // Skal modtage xml.
        private readonly int PORT;

        public UDPReceiver(int port)
        {
            PORT = port;
        }
        public void Start()
        {
            // Receive
            byte[] buffer = new byte[2048];


            try
            {
                UdpClient udp = new UdpClient(PORT);
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
                Console.WriteLine("Venter på at modtage: ");
                buffer = udp.Receive(ref senderEP);
                Console.WriteLine($"UDP datagram received lgt={buffer.Length}");
                Console.WriteLine($"Afsender er {senderEP.Address}, port {senderEP.Port}");

                // convert bytes to string
                String incommingStr = Encoding.ASCII.GetString(buffer);
                Console.WriteLine();
                Console.WriteLine("Det er hvad vi for fra clienten INDEN!!! den bliver Deserialiseret: ");
                Console.WriteLine(incommingStr);
                using (StringReader reader = new StringReader(incommingStr))
                {
                    XmlSerializer carSerializer = new XmlSerializer(typeof(Car));
                    Console.WriteLine(reader.ReadLine());
                    Car bil = (Car)carSerializer.Deserialize(reader);
                    Console.WriteLine();
                    Console.WriteLine("Bilen efter den er Deserialiseret: ");
                    Console.WriteLine(bil);
                }
                //Send Back
                String outgoingStr = incommingStr.ToUpper();
                byte[] outBuffer = Encoding.ASCII.GetBytes(outgoingStr);

                udp.Send(outBuffer, outBuffer.Length, senderEP);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            

        }
    }
}
