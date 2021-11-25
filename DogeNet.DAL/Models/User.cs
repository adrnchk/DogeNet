// <copyright file="User.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public partial class User
    {
        public User()
        {
            this.BlackListFriends = new HashSet<BlackList>();
            this.BlackListUsers = new HashSet<BlackList>();
            this.Comments = new HashSet<Comment>();
            this.ConversationParticipants = new HashSet<ConversationParticipant>();
            this.Conversations = new HashSet<Conversation>();
            this.FriendRequestFriends = new HashSet<FriendRequest>();
            this.FriendRequestUsers = new HashSet<FriendRequest>();
            this.GroupParticipants = new HashSet<GroupParticipant>();
            this.Groups = new HashSet<Group>();
            this.Likes = new HashSet<Like>();
            this.Messages = new HashSet<Message>();
            this.ProfilePosts = new HashSet<ProfilePost>();
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string IdentityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? StatusId { get; set; }

        public string Title { get; set; }

        public string AvatarImg { get; set; }

        public string CoverImg { get; set; }

        public int? CityId { get; set; }

        public string Bio { get; set; }

        public virtual IdentityUser Identity { get; set; }

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
