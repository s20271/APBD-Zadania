using Cw3.Models;
using System.Collections.Generic;

namespace Cw3.Services
{
    public interface IFileDbService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string indexNumber);
        void SetStudent(string indexNumber, Student s);
        bool AddStudent(Student student);
        void DeleteStudent(Student ds);
    }
}
