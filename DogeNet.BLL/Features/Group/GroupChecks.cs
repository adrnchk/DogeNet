// <copyright file="GroupChecks.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DogeNet.DAL;

    public class GroupChecks
    {
        public static bool PostIdValid(DBContext db, int id) => db.Groups.Any(o => o.Id == id);
    }
}
