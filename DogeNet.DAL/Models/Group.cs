using System;
using System.Collections.Generic;



namespace DogeNet.DAL.Models
{
   
    public partial class Group
    {

        public Group()
        {
            GroupParticipants = new HashSet<GroupParticipant>();
            OwnerPosts = new HashSet<OwnerPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string AvatarImg { get; set; }
        public string CoverImg { get; set; }
        public int? StatusId { get; set; }

        public virtual User Creator { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }
        public virtual ICollection<OwnerPost> OwnerPosts { get; set; }
    }
}
