using System;
using System.Collections.Generic;

namespace Sakila.Models
{
    public partial class FilmActor1
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }
        public DateTime LastUpdate { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }
}
