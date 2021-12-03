// <copyright file="AddParticipantConversationValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.AddParticipantConversation
{
    using DogeNet.BLL.Features.Account;
    using DogeNet.DAL;
    using FluentValidation;

    public class AddParticipantConversationValidator : AbstractValidator<AddParticipantConversationModel>
    {
        public AddParticipantConversationValidator(DBContext db)
        {
            this.RuleFor(enitity => enitity.AddedAt).NotNull();
            this.RuleFor(enitity => enitity.ConversationId).NotEmpty().NotNull()
                .Must(id => ConversationChecks.ConversationIdValid(db, id)).WithMessage("Conversation not found");
            this.RuleFor(enitity => enitity.UserId).NotEmpty().NotNull()
                .Must(id => AccountChecks.UserIdValid(db, id)).WithMessage("User not found");
            this.RuleFor(enitity => enitity.Title).NotEmpty();
        }
    }
}
