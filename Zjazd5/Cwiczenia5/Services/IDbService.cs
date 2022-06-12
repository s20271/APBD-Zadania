using Cwiczenia5.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia5.Services
{
    interface IDbService
    {
        Task<IEnumerable<SomeSortOfTrip>> GetTrips();
    }
}
