using Cwiczenia5.Models;
using Cwiczenia5.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia5.Services
{
    public class DbService : IDbService
    {
        private readonly s20271Context _context;

        public DbService(s20271Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SomeSortOfTrip>> GetTrips()
        {
            return await _context.Trips
                .OrderByDescending(e=>e.DateFrom)
                .Select(e => new SomeSortOfTrip
                {
                Name = e.Name,
                Description = e.Description,
                MaxPeople = e.MaxPeople,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                Countries = e.CountryTrips.Select(e=> new SomeSortOfCountry { Name = e.IdCountryNavigation.Name}).ToList(),
                Clients = e.ClientTrips.Select(e => new SomeSortOfClient { FirstName = e.IdClientNavigation.FirstName, LastName = e.IdClientNavigation.LastName}).ToList()
                }).ToListAsync();
        } 

        public async Task RemoveTrip(int id)
        {
            //var trip = await _context.Trips.Where(e => e.IdTrip == id).FirstOrDefaultAsync();
            var trip = new Trip() { IdTrip = id };
            _context.Attach(trip);
            _context.Remove(trip);
            await _context.SaveChangesAsync();
        }
    }
}
