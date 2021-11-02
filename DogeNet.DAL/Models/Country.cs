// <copyright file="Country.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System.Collections.Generic;

    public partial class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Flag { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
