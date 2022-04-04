using DeliVeggie.Models.Entity.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.RabbitMQ.Abstract
{
    public interface IRequester
    {
        IEnumerable<Product> GetAllProductsRequest();
        Product GetProductDetailsRequest(string id, int weekOfDay);

    }
}
