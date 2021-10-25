using System;
using System.Collections.Generic;


namespace DogeNet.DAL.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ConversationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Text { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual User User { get; set; }
    }
}
