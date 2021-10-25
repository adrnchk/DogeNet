using System;
using System.Collections.Generic;

#nullable disable

namespace DogeNet.DAL
{
    public partial class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ConversationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Text { get; set; }
    }
}
