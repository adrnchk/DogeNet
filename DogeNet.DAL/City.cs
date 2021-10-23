using System;
using System.Collections.Generic;

#nullable disable

namespace example1.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public string PhonePrefix { get; set; }
    }
}
