using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }

    }
}
