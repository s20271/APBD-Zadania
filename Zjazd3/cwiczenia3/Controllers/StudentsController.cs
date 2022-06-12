using Cw3.Models;
using Cw3.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Cw3.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IFileDbService _fileDbService;
        public StudentsController(IFileDbService fileDbService)
        {
            _fileDbService = fileDbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _fileDbService.GetStudents();
                return Ok(students);
            }
            catch (FileNotFoundException)
            {
                return BadRequest("Plik CSV nie zostal utworzony.");
            }
            catch (IOException)
            {
                return BadRequest("Plik CSV jest uzywany przez inny proces.");
            }
            catch (IndexOutOfRangeException)
            {
                FileDbService.studendsList = new List<Student>();
                return BadRequest("Plik CSV zostal utworzony ale jest pusty.");
            }
        }

        [HttpGet]
        [Route("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            try
            {
                var student = _fileDbService.GetStudent(indexNumber);
                return Ok(student);
            }
            catch (FileNotFoundException)
            {
                return BadRequest("Plik CSV nie zostal utworzony.");
            }
            catch (IOException)
            {
                return BadRequest("Plik CSV jest uzywany przez inny proces.");
            }
            catch (IndexOutOfRangeException)
            {
                FileDbService.studendsList = new List<Student>();
                return BadRequest("Plik CSV zostal utworzony ale jest pusty.");
            }
        }

        [HttpPut]
        [Route("{indexNumber}")]
        public IActionResult PutStudent(string indexNumber, Student student)
        {
            try
            {
                if (indexNumber is null) return BadRequest("Numer indeksu nie moze byc pusty");
                else if (!FileDbService.IsIndexNumberExists(indexNumber)) return BadRequest("W bazie nie ma studenta o podanym indeksie.");
                else if (student.IndexNumber != indexNumber) return BadRequest("Nie mozna zmieniac indeksu studenta.");
                else
                {
                    if (!FileDbService.CheckData(student).Equals("OK"))
                    {
                        return BadRequest(FileDbService.CheckData(student));
                    }
                    else
                    {
                        _fileDbService.SetStudent(indexNumber, student);
                        return Ok("Zaktualizowano: \nFirstName: " + student.FirstName + "\nLastName: " + student.LastName + "\nIndexNumber: " + student.IndexNumber + "\nDateOfBirth: "
                            + student.DateOfBirth + "\nDepartment: " + student.Department + "\nLearningMode: " + student.LearningMode
                            + "\nEmail: " + student.Email + "\nMotherName: " + student.MotherName + "\nFatherName: " + student.FatherName);
                    }
                }
            }
            catch (IOException)
            {
                return BadRequest("Plik CSV jest uzywany przez inny proces.");
            }
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                if (student is null)
                    return BadRequest();
                else
                {
                    if (FileDbService.IsIndexNumberExists(student.IndexNumber))
                    {
                        return BadRequest("Student o podanym indeksie jest juz zapisany w bazie studentow.");
                    }
                    if (!FileDbService.CheckData(student).Equals("OK"))
                    {
                        return BadRequest(FileDbService.CheckData(student));
                    }
                    else
                    {
                        return Ok(_fileDbService.AddStudent(student) ? "Student dodany" : "Student nie zostal dodany");
                    }
                }
            }
            catch (IOException)
            {
                return BadRequest("Plik CSV jest uzywany przez inny proces.");
            }
        }
        [HttpDelete]
        [Route("{indexNumber}")]
        public IActionResult DeleteStudent(string indexNumber) 
        {
            if(FileDbService.IsIndexNumberExists(indexNumber))
            {
                _fileDbService.DeleteStudent(_fileDbService.GetStudent(indexNumber));
                return Ok("Student usuniety");
            }
            else
            {
                return BadRequest("W bazie nie ma studenta o podanym numerze");
            }
        }
    }
}

