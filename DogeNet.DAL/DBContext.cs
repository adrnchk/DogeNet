// <copyright file="DBContext.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlackList> BlackLists { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Conversation> Conversations { get; set; }

        public virtual DbSet<ConversationParticipant> ConversationParticipants { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Friend> Friends { get; set; }

        public virtual DbSet<FriendRequest> FriendRequests { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<GroupParticipant> GroupParticipants { get; set; }

        public virtual DbSet<Like> Likes { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<GroupPost> OwnerPosts { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<PostContent> PostContents { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-QV2VVS8\\MSSQLSERVER01;Database=DogeNetDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
            this.OnModelCreating(modelBuilder);
        }
    }
}
