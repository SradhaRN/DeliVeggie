using DeliVeggie.Models.Entity.Product;
using DeliVeggie.MongoDB.Mdo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.MongoDB.Abstract
{
    public interface IPriceReductionRepository
    {
        Task<PriceReductionMdo> GetPriceReductionAsync(int dayOfWeek);
    }
}
