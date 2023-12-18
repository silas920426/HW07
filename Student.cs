using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chooselesson
{
    internal class Student
    {
        public String StudentId { get; set; }
        public String StudentName { get; set; }

        public override string ToString()
        {
            return $" {StudentId}    {StudentName}";
        }
    }
}
