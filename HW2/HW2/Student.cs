using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Student
    {
        public string name, lastName;
        public int gpa;
        public Student (string curName, string curLastName, int curGpa)
        {
            name = curName;
            lastName = curLastName;
            gpa = curGpa;
        }
        public Student(string name,string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }
        public override string ToString()
        {
            return name + " " + lastName + gpa;
        }
    }
}
