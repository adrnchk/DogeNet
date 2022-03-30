// <copyright file="PostChecks.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts
{
    using System.Linq;
    using DogeNet.DAL;

    public class PostChecks
    {
        public static bool PostIdValid(DBContext db, int id) => db.Posts.Any(o => o.Id == id);
    }
}
