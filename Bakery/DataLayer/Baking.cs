using DataLayer;
using System;

namespace DataLayer
{
    public  class Baking
    {
       
        public Baking(int Id, double Price, BakingType Type)
        {
            this.Id = Id;
            this.Price = Price;
            this.Type = Type;
           
        }

        public int Id { get; set; }
        public double Price { get; set; }

        public BakingType Type { get; set; }
    }
}
