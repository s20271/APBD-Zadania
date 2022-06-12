using cwiczenie6.DataAcces;
using cwiczenie6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenie6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DoctorController(MyDbContext context)
        {
            _context = context;
        }
     
        [HttpGet]
        public IActionResult GetDoctor()
        {
            return Ok(_context.Doctors);
        }

        [HttpPost]
        public IActionResult AddDoctor(string firstName, string lastName, string email)
        {
            Doctor newDoctor = new() {FirstName = firstName, LastName = lastName, Email = email };
            _context.Add(newDoctor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult EditDoctor(int idDoctor, string firstName, string lastName, string email)
        {
            var editDoctor = _context.Doctors.Where(i => i.IdDoctor == idDoctor).First();
            if (firstName != null) editDoctor.FirstName = firstName;
            if (lastName != null) editDoctor.LastName = lastName;
            if (email != null) editDoctor.Email = email;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(int idDoctor)
        {
            var delDoctor = new Doctor
            {
                IdDoctor = idDoctor
            };
            _context.Attach(delDoctor);
            _context.Doctors.Remove(delDoctor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
