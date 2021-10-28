using System;
using System.Collections.Generic;

namespace DogeNet.DAL.Models
{
    public partial class ProfilePost
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int PostId { get; set; }

        public virtual User Owner { get; set; }
        public virtual Post Post { get; set; }
    }
}
