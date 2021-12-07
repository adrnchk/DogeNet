// <copyright file="SendMessageHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Messages.SendMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using AutoMapper;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class SendMessageHandlerTests
    {
        private readonly DBContext context;
        private readonly SendMessageHandler handler;
        private readonly IMapper mapper;

        public SendMessageHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("TEST_ONLY");

            this.context = new DBContext(optionsBuilder.Options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<SendMessageModelProfile>());
            this.mapper = config.CreateMapper();

            this.handler = new SendMessageHandler(this.context, this.mapper);

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

            this.context.SaveChanges();
        }

        [Fact]
        public async void HandleNormalMessage()
        {
            var model = new SendMessageModel()
            {
                UserId = 1,
                ConversationId = 1,
                Text = "HandleNormalMessage",
            };

            var command = new SendMessageCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Equal(1, this.context.Messages.Where(entity => entity.Text.Equals(model.Text)).Count());
        }

        [Fact]
        public async void HandleErrorCommandNull()
        {
            try
            {
                SendMessageCommand command = null;

                await this.handler.Handle(command, CancellationToken.None);
            }
            catch (NullReferenceException e)
            {
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}
