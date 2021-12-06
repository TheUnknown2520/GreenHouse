using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Klima
    {
        public double Temperature { get; set; }
        public double humidity { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }

        public Klima()
        {

        }

        public Klima(DateTime date, double temperature, double humidity)

        {
            Temperature = temperature;
            this.humidity = humidity;
            Date = date;

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
