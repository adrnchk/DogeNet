// <copyright file="ConversationChecks.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations
{
    using System.Linq;
    using DogeNet.DAL;

    public static class ConversationChecks
    {
        public static bool ConversationIdValid(DBContext db, int id) => db.Conversations.Any(o => o.Id == id);
    }
}
