// <copyright file="GetBlackListModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetBlackList
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class GetBlackListModelProfiles : Profile
    {
        public GetBlackListModelProfiles()
        {
            this.CreateMap<BlackList, BlackListDetailsModel>();
        }
    }
}
