// <copyright file="DbInitializer.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
