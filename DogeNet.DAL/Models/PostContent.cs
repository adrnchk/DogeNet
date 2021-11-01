// <copyright file="PostContent.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;

    public partial class PostContent
    {
        public int Id { get; set; }

        public int? PostId { get; set; }

        public string Type { get; set; }

        public string FileName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string Url { get; set; }

        public virtual Post Post { get; set; }
    }
}
