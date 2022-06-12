using cwiczenie6.DataAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace cwiczenie6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresciptionController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PresciptionController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPrescription(int IdPrescription)
        {
            var prescription = _context.Prescriptions
                                        .Where(i => i.IdPrescription == IdPrescription)
                                        .Include(i => i.Patient)
                                        .Include(i => i.Doctor)
                                        .Include(i => i.Prescription_Medicaments)
                                        .ToList();
            return Ok(prescription);
        }
    }
}
