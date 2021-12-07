// <copyright file="MessagesDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.GetMessages
{
    using System;

    public class MessagesDetailsModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ConversationId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Text { get; set; }
    }
}
