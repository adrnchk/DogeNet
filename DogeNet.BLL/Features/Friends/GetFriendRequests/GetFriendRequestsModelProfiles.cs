// <copyright file="GetFriendRequestsModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriendRequests
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class GetFriendRequestsModelProfiles : Profile
    {
        public GetFriendRequestsModelProfiles()
        {
            this.CreateMap<FriendRequest, FriendRequestsDetailsModel>();
        }
    }
}
