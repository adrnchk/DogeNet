// <copyright file="SendMessageValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.SendMessage
{
    using DogeNet.BLL.Features.Account;
    using DogeNet.BLL.Features.Conversations;
    using DogeNet.DAL;
    using FluentValidation;

    public class SendMessageValidator : AbstractValidator<SendMessageModel>
    {
        public SendMessageValidator(DBContext db)
        {
            this.RuleFor(account => account.UserId).NotEmpty().NotNull()
                .Must(id => AccountChecks.UserIdValid(db, id)).WithMessage("Sender not found");
            this.RuleFor(account => account.ConversationId).NotNull().NotEmpty()
                .Must(id => ConversationChecks.ConversationIdValid(db, id)).WithMessage("Conversation not found");
            this.RuleFor(account => account.Text).NotNull().NotEmpty().MaximumLength(MessageConstants.MaxTextSizeForMessage);
        }
    }
}
