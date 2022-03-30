// <copyright file="CreatePostModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.CreatePost
{
    using System;
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class CreatePostModelProfiles : Profile
    {
        public CreatePostModelProfiles()
        {
            this.CreateMap<CreatePostModel, Post>()
                .ForMember(src => src.CreatedAt, opt => opt.MapFrom(c => DateTime.Now));
        }
    }
}
