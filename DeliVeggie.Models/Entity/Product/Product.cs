using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Models.Entity.Product
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
        //public IEnumerable<PriceReduction> PriceReductions { get; set; }
    }
}
