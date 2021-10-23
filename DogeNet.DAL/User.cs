using System;
using System.Collections.Generic;

#nullable disable

namespace example1.Models
{
    public partial class User
    {
        public User()
        {
            BlackListFriends = new HashSet<BlackList>();
            BlackListUsers = new HashSet<BlackList>();
            Comments = new HashSet<Comment>();
            ConversationParticipants = new HashSet<ConversationParticipant>();
            FriendRequestFriends = new HashSet<FriendRequest>();
            FriendRequestUsers = new HashSet<FriendRequest>();
            Likes = new HashSet<Like>();
            OwnerPosts = new HashSet<OwnerPost>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }
        public string Title { get; set; }
        public string AvatarImg { get; set; }
        public string CoverImg { get; set; }
        public int? CityId { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<BlackList> BlackListFriends { get; set; }
        public virtual ICollection<BlackList> BlackListUsers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ConversationParticipant> ConversationParticipants { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestFriends { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestUsers { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<OwnerPost> OwnerPosts { get; set; }
    }
}
