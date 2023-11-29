using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganTransplant
{
    internal class Person
    {
        public string _name;
        public int _age;
        public string _bloodType;
        public bool _smokes;
        public bool _alcoLast24;

        public Person(string name, int age, string bloodType, bool smokes, bool alcoLast24)
        {
            _name = name;
            _age = age;
            _bloodType = bloodType;
            _smokes = smokes;
            _alcoLast24 = alcoLast24;
        }
    }
}
