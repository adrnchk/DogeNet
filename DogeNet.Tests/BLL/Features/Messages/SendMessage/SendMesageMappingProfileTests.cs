// <copyright file="SendMesageMappingProfileTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Messages.SendMessage
{
    using AutoMapper;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.DAL.Models;
    using Xunit;

    public class SendMesageMappingProfileTests
    {
        private readonly IMapper mapper;

        public SendMesageMappingProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<SendMessageModelProfile>());
            this.mapper = config.CreateMapper();
        }

        [Fact]
        public void ToMessageMap()
        {
            var model = new SendMessageModel()
            {
                UserId = 1,
                ConversationId = 1,
                Text = null,
            };

            var message = new Message();

            message = this.mapper.Map<SendMessageModel, Message>(model);

            Assert.True(message.UserId == model.UserId && message.Text == model.Text && message.ConversationId == model.ConversationId);
        }
    }
}
