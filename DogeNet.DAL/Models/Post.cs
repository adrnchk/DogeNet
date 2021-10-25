using System;
using System.Collections.Generic;

#nullable disable

namespace DogeNet.DAL
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            PostContents = new HashSet<PostContent>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Text { get; set; }
        public bool? IsCommentAvailable { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<PostContent> PostContents { get; set; }
    }
}
