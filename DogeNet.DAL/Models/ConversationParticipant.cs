using System;
using System.Collections.Generic;



namespace DogeNet.DAL.Models
{
    public partial class ConversationParticipant
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public int UserId { get; set; }
        public DateTime? AddedAt { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual User User { get; set; }
    }
}
