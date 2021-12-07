using System;

namespace UDP_GreenHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            UDP_Reciever reciever = new UDP_Reciever();
            reciever.start();
            
        }
    }
}
