using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student : Man
    {
        public ushort StudeYear { get; private set; }
        public Student(string name, byte age, Gender gender, ushort weight, ushort studeYear) : base(name, age, gender, weight)
        {
            StudeYear = studeYear;
        }

        public Student(Man person, ushort studeYear) : base(person.Name, person.Age, person.Gend, person.Weight)
        {
            StudeYear = studeYear;
        }

        public void IncrementStudeYear(ushort years)
        {
            StudeYear += years;
        }

        public void SetStudeYear(ushort studeYear)
        {
            StudeYear = studeYear;
        }
    }
}
