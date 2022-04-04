using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Models.Entity.Product
{
    public class PriceReduction
    {
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}