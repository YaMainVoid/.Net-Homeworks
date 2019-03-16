using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Flower
    {
        public ushort Price { get; private set; }
        public ushort FlowerCount { get; private set; }
        public Flower(ushort price, ushort flowerCount = 1)
        {
            Price = price;
            FlowerCount = flowerCount;
        }
        abstract public void Smell();
    }
}
