using System;
using System.Collections.Generic;

namespace Sakila.Models
{
    public partial class FilmActor
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
