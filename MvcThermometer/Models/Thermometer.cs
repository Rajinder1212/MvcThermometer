using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcThermometer.Models
{
    public class Thermometer
    {
        public int Id { get; set; }
        public string Features { get; set; }
        public double Celcious { get; set; }
        public double Fahrenheit { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
    }
}
