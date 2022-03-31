// <copyright file="EditPostModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.EditPost
{
    using AutoMapper;
    using DogeNet.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EditPostModelProfiles : Profile
    {
        public EditPostModelProfiles()
        {
            this.CreateMap<EditPostModel, Post>();
        }
    }
}
