using DeliVeggie.Models.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggie.Services.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductDetails(string productId);
    }
}
