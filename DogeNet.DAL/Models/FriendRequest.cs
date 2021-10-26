﻿using System;
using System.Collections.Generic;


namespace DogeNet.DAL.Models
{
    public partial class FriendRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User Friend { get; set; }
        public virtual User User { get; set; }
    }
}
