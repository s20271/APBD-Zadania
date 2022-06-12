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
    public class AlbumController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AlbumController(MyDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAlbum(int IdAlbum) 
        {
            var Album = _context.Album.Where(i => i.IdAlbum == IdAlbum).Include(i => i.Tracks);
            return Ok(Album);
        }

    }
}
