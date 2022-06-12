using Cw3.Models;
using System.Collections.Generic;

namespace cwiczenia3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }

}
