// <copyright file="AccountChecks.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account
{
    using System.Linq;
    using DogeNet.DAL;

    public static class AccountChecks
    {
        public static bool UniqueName(DBContext db, string name) => db.Users.Any(o => o.UserName == name);

        public static bool UserIdValid(DBContext db, int id) => db.AppUsers.Any(o => o.Id == id);
    }
}
