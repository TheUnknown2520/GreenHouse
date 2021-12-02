using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Klima
    {
        public int Temperature { get; set; }
        public int humidity { get; set; }
        public DateTime Date { get; private set; }

      

        public Klima(int temperature, int humidity, DateTime date )
        {
            Temperature = temperature;
            this.humidity = humidity;
            date = DateTime.Now;

        }




        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            try
            {
                var OtherKlima = (Klima)obj;
                if (this.Date.Equals(OtherKlima.Date) && this.Temperature.Equals(OtherKlima.Temperature) &&
                    this.humidity.Equals(OtherKlima.humidity)) return true;
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }

        }

        public override string ToString()
        {
            return $"klima: dato - {Date} Tempartur - {Temperature} Luftfugtighed - {humidity}  ";
        }


    }
}
