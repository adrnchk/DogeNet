// <copyright file="EditGroupModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.EditGroup
{
    public class EditGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string AvatarImg { get; set; }

        public string CoverImg { get; set; }

        public int StatusId { get; set; }
    }
}
