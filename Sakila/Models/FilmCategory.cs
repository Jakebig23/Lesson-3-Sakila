using System;
using System.Collections.Generic;

namespace Sakila.Models
{
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public byte CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public Category Category { get; set; }
        public Film Film { get; set; }
    }
}
