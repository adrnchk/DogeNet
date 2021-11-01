// <copyright file="Comment.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;

    public partial class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        public DateTime? AddedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Text { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
