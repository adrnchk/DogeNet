// <copyright file="DeleteMessageHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Messages.DeleteMessage
{
    using System.Threading;
    using DogeNet.BLL.Features.Messages.DeleteMesage;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class DeleteMessageHandlerTests
    {
        private readonly DBContext context;
        private readonly DeleteMessageHandler handler;

        public DeleteMessageHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("TEST_DELETE");

            this.context = new DBContext(optionsBuilder.Options);

            this.handler = new DeleteMessageHandler(this.context);

            var sender = new User()
            {
                UserName = "user1",
            };

            var reciever = new User()
            {
                UserName = "user2",
            };

            var conversation = new Conversation()
            {
                Title = "test_delete",
            };

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
            var query = new DeleteMessageCommand(1);

            await this.handler.Handle(query, CancellationToken.None);

            Assert.Empty(this.context.Messages);
        }
    }
}
