using System;
using System.Collections.Generic;

namespace Sakila.Models
{
    public partial class Film
    {
        public Film()
        {
            FilmActor1 = new HashSet<FilmActor1>();
            FilmCategory = new HashSet<FilmCategory>();
            Inventory = new HashSet<Inventory>();
        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public byte LanguageId { get; set; }
        public byte? OriginalLanguageId { get; set; }
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<FilmActor1> FilmActor1 { get; set; }
        public ICollection<FilmCategory> FilmCategory { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
