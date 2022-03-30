// <copyright file="PostDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.GetPost
{
    using System;

    public class PostDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CreatorId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Text { get; set; }

        public bool IsCommentAvailable { get; set; }
    }
}
