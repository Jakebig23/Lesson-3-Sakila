using System;
using System.Collections.Generic;

namespace Sakila.Models
{
    public partial class Actor
    {
        public Actor()
        {
            FilmActor1 = new HashSet<FilmActor1>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<FilmActor1> FilmActor1 { get; set; }
    }
}
