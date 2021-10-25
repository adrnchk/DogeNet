using System;
using System.Collections.Generic;



namespace DogeNet.DAL.Models
{
    public partial class City
    {

        public City()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public string PhonePrefix { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
