// <copyright file="GetPostModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.GetPost
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class GetPostModelProfile : Profile
    {
        public GetPostModelProfile()
        {
            this.CreateMap<Post, PostDetailsModel>();
        }
    }
}
