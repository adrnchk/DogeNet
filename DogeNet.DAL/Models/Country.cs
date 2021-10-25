using System;
using System.Collections.Generic;

namespace DogeNet.DAL.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
