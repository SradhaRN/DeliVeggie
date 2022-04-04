using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Models.Entity.Response
{
    public class ProductListResponseData
    {
        public IEnumerable<ProductDetailsResponseData> Products { get; set; }
    }
}
