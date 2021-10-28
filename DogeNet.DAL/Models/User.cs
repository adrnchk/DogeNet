using System;
using System.Collections.Generic;



namespace DogeNet.DAL.Models
{
    
    public partial class User
    {
        public User()
        {
            BlackListFriends = new HashSet<BlackList>();
            BlackListUsers = new HashSet<BlackList>();
            Comments = new HashSet<Comment>();
            ConversationParticipants = new HashSet<ConversationParticipant>();
            Conversations = new HashSet<Conversation>();
            FriendRequestFriends = new HashSet<FriendRequest>();
            FriendRequestUsers = new HashSet<FriendRequest>();
            GroupParticipants = new HashSet<GroupParticipant>();
            Groups = new HashSet<Group>();
            Likes = new HashSet<Like>();
            Messages = new HashSet<Message>();
            ProfilePosts = new HashSet<ProfilePost>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? StatusId { get; set; }
        public string Title { get; set; }
        public string AvatarImg { get; set; }
        public string CoverImg { get; set; }
        public int? CityId { get; set; }
        public string Bio { get; set; }

        public virtual City City { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<BlackList> BlackListFriends { get; set; }
        public virtual ICollection<BlackList> BlackListUsers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ConversationParticipant> ConversationParticipants { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestFriends { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestUsers { get; set; }
        public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ProfilePost> ProfilePosts { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
