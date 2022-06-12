
using kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MusicianController(MyDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        public IActionResult DeleteMusician(int IdMusician)
        {

            int IdMusiciana = _context.Musician.Select(c=>c.IdMusician)
            return Ok();
        }

    }
}
