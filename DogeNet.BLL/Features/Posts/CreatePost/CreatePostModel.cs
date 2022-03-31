// <copyright file="CreatePostModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.CreatePost
{
    public class CreatePostModel
    {
        public string Title { get; set; }

        public int? CreatorId { get; set; }

        public string Text { get; set; }

        public bool? IsCommentAvailable { get; set; }
    }
}
