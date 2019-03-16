using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int GetCommonPrice(List<Flower> flowers)
        {
            int commonPrice = 0;
            foreach (var flower in flowers)
            {
                commonPrice += flower.Price * flower.FlowerCount;
            }
            return commonPrice;
        }
        static void Main(string[] args)
        {
            List<Flower> flowers = new List<Flower>();
            Rose rose = new Rose(222, 10);
            flowers.Add(rose);
            Carnation carnations = new Carnation(100, 50);
            flowers.Add(carnations);
            Tulip tulp = new Tulip(150);
            flowers.Add(tulp);
            tulp.Smell();
            Daisy daisies = new Daisy(50, 60);
            flowers.Add(daisies);
            Lily lilies = new Lily(99, 99);
            flowers.Add(lilies);
            lilies.Smell();
            int totalPrice = GetCommonPrice(flowers);
            Console.WriteLine("Common price is equal " + totalPrice);
        }
    }
}
