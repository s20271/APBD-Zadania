using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter
{
    public class Student : IEqualityComparer<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string LearningMode { get; set; }
        public string IndexNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }

        public bool Equals(Student x, Student y)
        {
            return (x.FirstName == y.FirstName) && (x.LastName == y.LastName) && (x.IndexNumber == y.IndexNumber);
        }

        public int GetHashCode(Student s)
        {
            return s.IndexNumber.GetHashCode();
        }
    }


}
