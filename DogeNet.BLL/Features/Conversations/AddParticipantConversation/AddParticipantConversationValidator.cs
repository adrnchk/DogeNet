// <copyright file="AddParticipantConversationValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.AddParticipantConversation
{
    using FluentValidation;

    public class AddParticipantConversationValidator : AbstractValidator<AddParticipantConversationModel>
    {
        public AddParticipantConversationValidator()
        {
            this.RuleFor(enitity => enitity.AddedAt).NotNull();
            this.RuleFor(enitity => enitity.ConversationId).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity.UserId).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity.Title).NotEmpty();
        }
    }
}
