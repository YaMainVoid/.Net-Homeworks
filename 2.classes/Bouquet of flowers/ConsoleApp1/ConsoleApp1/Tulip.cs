using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tulip : Flower
    {
        public Tulip(ushort price, ushort flowerCount = 1) : base(price, flowerCount)
        {
        }

        public override void Smell()
        {
            //many biological processes..
            Console.WriteLine("Tulip stars smell");
        }
    }
}
