using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }

        public int IdAlbum { get; set; }
        public virtual Album Album { get; set; }
    }
}
