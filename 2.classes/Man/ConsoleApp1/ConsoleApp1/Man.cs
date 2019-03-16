using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Man
    {
        public string Name { get; protected set; }
        public byte Age { get; protected set; }
        public Gender Gend { get; protected set; }
        public ushort Weight { get; protected set; }

        public Man(string name, byte age, Gender gender, ushort weight)
        {
            Name = name;
            Age = age;
            Gend = gender;
            Weight = weight;
        }

        public void SetName(string newName)
        {
            Name = newName;
        }

        public void SetAge(byte newAge)
        {
            Age = newAge;
        }

        public void SetWeight(ushort newWeight)
        {
            Weight = newWeight;
        }
    }
}
