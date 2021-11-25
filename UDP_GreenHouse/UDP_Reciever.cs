using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace UDP_GreenHouse
{
    class UDP_Reciever
    {
        public UDP_Reciever()
        {
            
        }

        public void start()
        {

            
            UdpClient client = new UdpClient(7777);
            byte[] data; //Array for data modtagelse 

            IPEndPoint piEndPoint = null; 

           data = client.Receive(ref piEndPoint);

           Console.WriteLine($"Modtaget IP = {piEndPoint.Address}, port: {piEndPoint.Port}  ");

           string str = Encoding.UTF8.GetString(data);

           Console.WriteLine("modtaget data " + str);

           string txt = JsonSerializer.Serialize(str); //Lavet om til json tekst
            
           byte[] bufferTilbage = Encoding.UTF8.GetBytes(txt);

           while (true)
           {
               Thread.Sleep(1000);
               client.Send(bufferTilbage, bufferTilbage.Length, new IPEndPoint(piEndPoint.Address, piEndPoint.Port ));
           }
        }

    }
}
