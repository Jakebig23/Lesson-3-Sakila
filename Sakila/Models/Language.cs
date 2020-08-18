using System;
using System.Collections.Generic;

namespace Sakila.Models
{
    public partial class Language
    {
        public byte LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
