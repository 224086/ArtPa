using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataGeneration
{
     public class FixedGenerator : IGenerator
    {

        public void GenarateData(DataContext data)
        {
            Client c1 = new Client("Artur", "Rojek", "1");
            data.clients.Add(c1);
            Client c2 = new Client("John", "Rambo", "2");
            data.clients.Add(c2);
            Client c3 = new Client("Robert", "Kubica", "3");
            data.clients.Add(c3);
            Client c4 = new Client("Bartek", "Stasiak", "4");
            data.clients.Add(c3);

            Baking b1 = new Baking(1, 2.5, BakingType.bun);
            data.catalog.products.Add(1, b1);
            Baking b2 = new Baking(2, 3.1, BakingType.bagel);
            data.catalog.products.Add(2, b2);
            Baking b3 = new Baking(3, 12.9, BakingType.cake);
            data.catalog.products.Add(3, b3);
            Baking b4 = new Baking(4, 0.2, BakingType.cookie);
            data.catalog.products.Add(4, b4);

            data.shop.catalog = data.catalog;

            for (int i = 1; i <= data.catalog.products.Count; i++)
            {
                data.shop.inventory.Add(data.catalog.products[i].Id, 10);
            }

        }
    }
}
