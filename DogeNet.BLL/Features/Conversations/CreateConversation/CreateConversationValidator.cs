// <copyright file="CreateConversationValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.CreateConversation
{
    using FluentValidation;

    public class CreateConversationValidator : AbstractValidator<CreateConversationModel>
    {
        public CreateConversationValidator()
        {
            this.RuleFor(enitity => enitity.CreatorId).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity.Title).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity.SecondUserId).NotEmpty().NotNull().NotEqual(entity => entity.CreatorId);
            this.RuleFor(enitity => enitity.AvatarImg).NotEmpty();
        }
    }
}
