using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonUDPReceiver
{
    public class UDPReceiver
    {
        private readonly int PORT;

        public UDPReceiver(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            using (UdpClient udpclient = new UdpClient(PORT))
            {

                try
                {
                    while (true)
                    {
                        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
                        Console.WriteLine("Venter på at modtage: ");
                        byte[] recieved = udpclient.Receive(ref endPoint);
                        Console.WriteLine("Modtaget fra adresse: " + endPoint.Address + " På port nummer: " + endPoint.Port);

                        string str = Encoding.ASCII.GetString(recieved);
                        Car modtagetbil = JsonConvert.DeserializeObject<Car>(str);

                        Console.WriteLine("Modtaget fra client: " + modtagetbil);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }

                
            }
        }
    }
}
