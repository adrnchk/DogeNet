// <copyright file="CreateGroupModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.CreateGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class CreateGroupModelProfiles : Profile
    {
        public CreateGroupModelProfiles()
        {
            this.CreateMap<CreateGroupModel, Group>()
                .ForMember(src => src.CreatedAt, opt => opt.MapFrom(c => DateTime.Now));
        }
    }
}
