// <copyright file="Like.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    public partial class Like
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
