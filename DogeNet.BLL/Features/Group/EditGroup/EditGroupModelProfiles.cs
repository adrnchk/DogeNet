// <copyright file="EditGroupModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.EditGroup
{
    using System;
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class EditGroupModelProfiles : Profile
    {
        public EditGroupModelProfiles()
        {
            this.CreateMap<EditGroupModel, Group>();
        }
    }
}
