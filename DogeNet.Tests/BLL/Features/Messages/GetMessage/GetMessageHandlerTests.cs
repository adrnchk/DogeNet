﻿// <copyright file="GetMessageHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Messages.GetMessage
{
    using System.Linq;
    using System.Threading;
    using DogeNet.BLL.Features.Messages.GetMessage;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class GetMessageHandlerTests
    {
        private readonly DBContext context;
        private readonly GetMessagesHandler handler;

        public GetMessageHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("TEST_GET");

            this.context = new DBContext(optionsBuilder.Options);

            this.handler = new GetMessagesHandler(this.context);

            var sender = new User()
            {
                UserName = "user1",
            };

            var reciever = new User()
            {
                UserName = "user2",
            };

            var conversation = new Conversation();

            this.context.Conversations.Add(conversation);
            this.context.AppUsers.Add(sender);
            this.context.AppUsers.Add(reciever);

            var participantSender = new ConversationParticipant()
            {
                User = sender,
                Conversation = conversation,
            };

            var participantReciever = new ConversationParticipant()
            {
                User = reciever,
                Conversation = conversation,
            };

            this.context.ConversationParticipants.Add(participantSender);
            this.context.ConversationParticipants.Add(participantReciever);

            var message = new Message()
            {
                UserId = 1,
                ConversationId = 1,
                Text = "testGet",
            };

            this.context.Messages.Add(message);

            this.context.SaveChanges();
        }

        [Fact]
        public async void HandleNormalMessage()
        {
            var query = new GetMessagesQuery(1);

            await this.handler.Handle(query, CancellationToken.None);

            Assert.Equal(1, this.context.Messages.Where(entity => entity.Text.Equals("testGet")).Count());
        }
    }
}