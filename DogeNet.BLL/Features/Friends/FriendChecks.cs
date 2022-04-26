// <copyright file="FriendChecks.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends
{
    using System.Linq;
    using DogeNet.DAL;

    public static class FriendChecks
    {
        public static bool IsInBlackList(DBContext context, int userId, int friendId) =>
            context.BlackLists.Any(entity =>
            (entity.UserId == userId && entity.FriendId == friendId) || (entity.UserId == friendId && entity.FriendId == userId));

        public static bool IsAlreadyFriends(DBContext context, int userId, int friendId) =>
            context.Friends.Any(entity =>
            (entity.UserId == userId && entity.FriendId == friendId) || (entity.UserId == friendId && entity.FriendId == userId));

    }
}
