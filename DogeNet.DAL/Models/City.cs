// <copyright file="City.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System.Collections.Generic;

    public partial class City
    {
        public City()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public string PhonePrefix { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
