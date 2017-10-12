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

namespace XmlUDPSender
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
            Car bil01 = new Car("Tesla", "red", "EL23400");
            
            IPEndPoint EP = new IPEndPoint(IPAddress.Broadcast, PORT);
            UdpClient udp = new UdpClient();

            XmlSerializer xs = new XmlSerializer(typeof(Car));
            StringWriter sw = new StringWriter();

            xs.Serialize(sw, bil01);

            Console.WriteLine("Her sender vi et bil objekt som XML til en server: ");
            Console.WriteLine(sw.ToString());

            byte[] data = Encoding.ASCII.GetBytes(sw.ToString());
            udp.Send(data, data.Length, EP);


        }
    }
}
