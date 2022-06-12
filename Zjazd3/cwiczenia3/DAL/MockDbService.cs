using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>()
            {
               new Student{FirstName = "Jan", LastName = "Kowalski", IndexNumber = "s1"},
               new Student{FirstName = "Joanna", LastName = "Malinowska", IndexNumber = "s2"},
               new Student{FirstName = "Andrzej", LastName = "Doczesny", IndexNumber = "s3"},
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
