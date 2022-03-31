// <copyright file="EditPostModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.EditPost
{
    public class EditPostModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public bool? IsCommentAvailable { get; set; }
    }
}
