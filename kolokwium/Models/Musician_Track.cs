using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Musician_Track
    {
        public int IdMusician { get; set; }
        public virtual Musician Musician { get; set; }

        public int IdTrack { get; set; }
        public virtual Track Track { get; set; }

}
}
