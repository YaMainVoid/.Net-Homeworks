using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Man man = new Man("Петя", 47, Gender.Male, 555);
            Student student1 = new Student("Анатолий", 16, Gender.Male, 70, 2019);
            Student student2 = new Student(man, 2019);
            man.SetWeight(300);
            Teacher teacher = new Teacher("Ann", 25, Gender.Female, 60);
            teacher.Explain();
            teacher.Explain(student1);
        }
    }
}
