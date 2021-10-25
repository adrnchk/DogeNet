using System;
using System.Collections.Generic;



namespace DogeNet.DAL.Models
{
    public partial class Conversation
    {
        public Conversation()
        {
            ConversationParticipants = new HashSet<ConversationParticipant>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string AvatarImg { get; set; }
        public int? StatusId { get; set; }

        public virtual User Creator { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ConversationParticipant> ConversationParticipants { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
