using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.MongoDB.Mdo
{
    public class PriceReductionMdo
    {
        public ObjectId Id { get; set; }
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}