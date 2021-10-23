using System;
using System.Collections.Generic;

#nullable disable

namespace example1.Models
{
    public partial class Conversation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string AvatarImg { get; set; }
        public bool? IsActive { get; set; }
    }
}
