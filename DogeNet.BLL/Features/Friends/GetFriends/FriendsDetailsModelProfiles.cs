// <copyright file="FriendsDetailsModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriends
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class FriendsDetailsModelProfiles : Profile
    {
        public FriendsDetailsModelProfiles()
        {
            this.CreateMap<User, FriendsDetailsModel>();
        }
    }
}
