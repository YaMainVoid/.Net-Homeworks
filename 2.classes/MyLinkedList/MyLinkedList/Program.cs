using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            linkedList.Add(4);
            linkedList.Add(3);
            linkedList.Add(5);
            linkedList.Add(1);
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("::::::::::::::::::::");
            linkedList.SetOnFirst();
            linkedList.Add(2);
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
