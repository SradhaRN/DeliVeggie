using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Models.Entity.Response
{
    public class ProductDetailsResponseData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
    }
}
