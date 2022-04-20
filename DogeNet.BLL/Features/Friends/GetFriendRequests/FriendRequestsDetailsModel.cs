// <copyright file="FriendRequestsDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriendRequests
{
    public class FriendRequestsDetailsModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }
    }
}
