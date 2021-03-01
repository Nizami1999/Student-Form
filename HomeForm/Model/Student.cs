using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeForm.Model
{
    class Student
    {
        public uint ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public byte Age { get; set; }
        public string Specification { get; set; }
        private static uint IDGenerator { get; set; } = 1;
        public Student(string _firstName, string _lastName, string _groupName)
        {
            FirstName = _firstName;
            LastName = _lastName;
            GroupName = _groupName;
            ID = IDGenerator++;
        }
        public Student(string _firstName, string _lastName, string _groupName, string _specification, byte _age) : this(_firstName, _lastName, _groupName)
        {
            Specification = _specification;
            Age = _age;
        }
        public override string ToString()
        {
            return $"{ID}. {FirstName} {LastName} \tGroup: {GroupName}";
        }
    }

}
