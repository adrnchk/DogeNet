// <copyright file="SendMesageValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Messages.SendMessage
{
    using DogeNet.BLL.Features.Messages;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class SendMesageValidatorTests
    {
        private readonly DBContext context;
        private readonly SendMessageValidator validator;

        public SendMesageValidatorTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseInMemoryDatabase("TEST_ONLY");

            this.context = new DBContext(optionsBuilder.Options);

            this.validator = new SendMessageValidator(this.context);

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
        public void ValidationNormal()
        {
            var model = new SendMessageModel()
            {
                UserId = 1,
                ConversationId = 1,
                Text = "Hello world",
            };

            var validationResults = this.validator.Validate(model);

            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void ValidationTooLargeText()
        {
            var model = new SendMessageModel()
            {
                UserId = 1,
                ConversationId = 1,
                Text = new string('-', MessageConstants.MaxTextSizeForMessage + 1),
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNotValidUser()
        {
            var model = new SendMessageModel()
            {
                UserId = int.MaxValue,
                ConversationId = 1,
                Text = "Hello world",
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNotValidConversation()
        {
            var model = new SendMessageModel()
            {
                UserId = 1,
                ConversationId = int.MaxValue,
                Text = "Hello world",
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNull()
        {
            var model = new SendMessageModel()
            {
                UserId = 1,
                ConversationId = 1,
                Text = null,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationEmpty()
        {
            var model = new SendMessageModel()
            {
                UserId = 1,
                ConversationId = 1,
                Text = string.Empty,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }
    }
}
