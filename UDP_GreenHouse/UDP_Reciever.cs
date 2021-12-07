using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ModelLib;

namespace UDP_GreenHouse
{
    class UDP_Reciever
    {
        public const int Port = 7777;

        public void start()
        {

            UdpClient client = new UdpClient(Port);
            byte[] data; //Array for data modtagelse 

            IPEndPoint piEndPoint = null;

            HttpClient restClient = new HttpClient();
            while (true)
            {
                data = client.Receive(ref piEndPoint);
                Console.WriteLine($"Modtaget IP = {piEndPoint.Address}, port: {piEndPoint.Port}  ");
                string str = Encoding.UTF8.GetString(data);
                Console.WriteLine("modtaget data " + str);

                //string[] klima = str.Split(' ');
                //string json = "{" + $"\"date: \": {klima[1]} {klima[2]}, \"temperature: \": {klima[4]}, \"humidity \": {klima[6]}" + "}";

                string[] s = str.Split(' ');
                Klima klima = new Klima(DateTime.Parse(s[1] + " " + s[2]) , double.Parse(s[4], new CultureInfo("en-UK")), double.Parse(s[6], new CultureInfo("en-UK")));

                StringContent content = new StringContent(JsonSerializer.Serialize(klima), Encoding.UTF8, "application/json");
                var retur = restClient.PostAsync("http://localhost:25347/api/Klima", content);
                var x = retur.Result;
                

            }


        }



    }
}
