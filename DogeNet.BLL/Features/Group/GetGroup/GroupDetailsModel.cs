// <copyright file="GroupDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetGroup
{
    using System;

    public class GroupDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public int? CreatorId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string AvatarImg { get; set; }

        public string CoverImg { get; set; }

        public int? StatusId { get; set; }

    }
}
