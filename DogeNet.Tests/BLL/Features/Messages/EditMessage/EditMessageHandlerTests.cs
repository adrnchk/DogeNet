// <copyright file="EditMessageHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Messages.EditMessage
{
    using System;
    using System.Threading;
    using AutoMapper;
    using DogeNet.BLL.Features.Messages.EditMessage;
    using DogeNet.BLL.Features.Messages.GetMessages;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class EditMessageHandlerTests
    {
        private readonly DBContext context;
        private readonly EditMessageHandler handler;
        private readonly IMapper mapper;

        public EditMessageHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("TEST_EDIT");

            this.context = new DBContext(optionsBuilder.Options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<GetMessagesModelProfile>());
            this.mapper = config.CreateMapper();

            this.handler = new EditMessageHandler(this.context, this.mapper);

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
        public async void HandleNormalMessageEdit()
        {
            var model = new EditMessageModel()
            {
                MessageId = 1,
                Text = "HandleNormalMessageEdit",
            };

            var command = new EditMessageCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Equal(model.Text, this.context.Messages.Find(1).Text);
        }

        [Fact]
        public async void HandleErrorModelNull()
        {
            try
            {
                EditMessageModel model = null;
                var command = new EditMessageCommand(model);

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

        [Fact]
        public async void HandleErrorCommandNull()
        {
            try
            {
                EditMessageCommand command = null;

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
