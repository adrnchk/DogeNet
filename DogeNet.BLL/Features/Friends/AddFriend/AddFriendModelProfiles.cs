// <copyright file="AddFriendModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.AddFriend
{
    using System;
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class AddFriendModelProfiles : Profile
    {
        public AddFriendModelProfiles()
        {
            this.CreateMap<AddFriendModel, FriendRequest>()
                .ForMember(src => src.CreatedAt, opt => opt.MapFrom(c => DateTime.Now));

            this.CreateMap<AddFriendModel, Friend>()
                .ForMember(src => src.CreatedAt, opt => opt.MapFrom(c => DateTime.Now));
        }
    }
}
