using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spliter
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello world, it is me. I like programming and sexy girls. May be smt else. GG BB WoRlD. So Okey OkeY SO so Okey okokoe";
            StringManipulator spliter = new StringManipulator(text);
            Console.WriteLine("Full info");
            spliter.ShowFullInfo();
            Console.WriteLine("Reduced info");
            spliter.ShowReducedInfo();
        }
    }
}
