using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataGeneration
{
    public class RandomGenerator : IGenerator
    {

        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public BakingType randomBakingType()
        {
            Array values = Enum.GetValues(typeof(BakingType));
            BakingType randomBakingType = (BakingType)values.GetValue(random.Next(values.Length));
            return randomBakingType;
        }

        public double randomPrice(double minimum, double maximum)
        {
            return random.NextDouble() *(maximum - minimum) + minimum;
        }

        public void GenarateData(DataContext data)
        {


            for (int i = 1; i <= 9; i++)
            {
               
               
                Baking baking = new Baking(i, randomPrice(5.00, 15.90), randomBakingType());
                data.catalog.products.Add(i, baking);

                Client client = new Client(GenerateRandomString(6), GenerateRandomString(13), i.ToString());
                data.clients.Add(client);
            }

        }
    }
}
