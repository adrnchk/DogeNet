// <copyright file="CreateGroupModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.CreateGroup
{
    public class CreateGroupModel
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public int CreatorId { get; set; }

        public string AvatarImg { get; set; }

        public string CoverImg { get; set; }

        public int StatusId { get; set; }
    }
}