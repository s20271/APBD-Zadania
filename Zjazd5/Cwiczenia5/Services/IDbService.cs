using Cwiczenia5.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia5.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfTrip>> GetTrips();
        Task RemoveTrip(int id);
    }
}
