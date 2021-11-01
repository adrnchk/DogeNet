// <copyright file="Post.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
            this.PostContents = new HashSet<PostContent>();
            this.GroupPosts = new HashSet<GroupPost>();
            this.ProfilePosts = new HashSet<ProfilePost>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int? CreatorId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Text { get; set; }

        public bool? IsCommentAvailable { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<GroupPost> GroupPosts { get; set; }

        public virtual ICollection<ProfilePost> ProfilePosts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<PostContent> PostContents { get; set; }
    }
}
