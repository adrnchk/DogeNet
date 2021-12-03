// <copyright file="MessageChecks.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages
{
    using System.Linq;
    using DogeNet.DAL;

    public static class MessageChecks
    {
        public static bool MessageIdValid(DBContext db, int id)
        {
            if (db.Messages.Where(o => o.Id == id).Count() == 1)
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
