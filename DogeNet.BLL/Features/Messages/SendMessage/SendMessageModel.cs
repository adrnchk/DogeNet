// <copyright file="SendMessageModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.SendMessage
{
    public class SendMessageModel
    {
        public int UserId { get; set; }

        public int ConversationId { get; set; }

        public string Text { get; set; }
    }
}
