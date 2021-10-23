using System;
using System.Collections.Generic;

#nullable disable

namespace example1.Models
{
    public partial class Group
    {
        public Group()
        {
            OwnerPosts = new HashSet<OwnerPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string AvatarImg { get; set; }
        public string CoverImg { get; set; }
        public string Status { get; set; }

        public virtual ICollection<OwnerPost> OwnerPosts { get; set; }
    }
}
