using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSeminar1.Models
{
    internal abstract class Employee
    {
        private double salary;
        public double Salary { get { return salary; } }

        public Employee(double salary)
        {
            this.salary = salary;
        }

        public override string ToString()
        {
            return "salary: " + salary;
        }
    }
}
