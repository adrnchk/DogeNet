using System;
using System.Collections.Generic;

#nullable disable

namespace example1.Models
{
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
