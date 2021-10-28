using System;
using System.Collections.Generic;


namespace DogeNet.DAL.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            PostContents = new HashSet<PostContent>();
            GroupPosts = new HashSet<GroupPost>();
            ProfilePosts = new HashSet<ProfilePost>();
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
