// <copyright file="AccountChecks.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account
{
    using System.Linq;
    using DogeNet.DAL;

    public static class AccountChecks
    {
        public static bool UniqueName(DBContext db, string name)
        {
            if (db.Users.Where(o => o.UserName == name).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
