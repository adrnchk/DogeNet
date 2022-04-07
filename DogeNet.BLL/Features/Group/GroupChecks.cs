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
        public static bool DoesGroupExist(DBContext db, int id) => db.Groups.Any(o => o.Id == id);

        public static bool IsUrlImgCorrect(string source) => Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
    }
}
