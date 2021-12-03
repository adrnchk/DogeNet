// <copyright file="SendMessageValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.SendMessage
{
    using FluentValidation;

    public class SendMessageValidator : AbstractValidator<SendMessageModel>
    {
        public SendMessageValidator()
        {
            this.RuleFor(account => account.UserId).NotEmpty().NotNull();
            this.RuleFor(account => account.ConversationId).NotNull().NotEmpty();
            this.RuleFor(account => account.CreatedAt).NotNull().NotEmpty();
            this.RuleFor(account => account.Text).NotNull().NotEmpty();
        }
    }
}
