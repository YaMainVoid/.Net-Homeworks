using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Teacher : Man
    {
        public Teacher(string name, byte age, Gender gender, ushort weight) : base(name, age, gender, weight)
        {
        }

        public Teacher(Man person) : base(person.Name, person.Age, person.Gend, person.Weight)
        {
        }

        //the teacher explains the topic to the whole class
        public void Explain()
        {
            Console.WriteLine("Lesson has begun");
            for (int minutes = 1; minutes <= 45; minutes++)
            {
                //teacher works so hard
                Thread.Sleep(50);
                Console.WriteLine($"Elapsed {minutes} min");
            }
            Console.WriteLine("Lesson has ended");
        }

        //the teacher explains the topic to one student
        public void Explain(Student student)
        {
            Console.WriteLine($"student {student.Name} is ready to begin the lesson");
            for (int minutes = 1; minutes <= 45; minutes++)
            {
                //teacher works so hard
                Thread.Sleep(50);
                Console.WriteLine($"Elapsed {minutes} min for {student.Name}");
            }
            Console.WriteLine($"{student.Name} has tired");
        }
    }
}
