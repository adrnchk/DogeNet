// <copyright file="GetGroupModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class GetGroupModelProfiles : Profile
    {
        public GetGroupModelProfiles()
        {
            this.CreateMap<Group, GroupDetailsModel>();
        }
    }
}
