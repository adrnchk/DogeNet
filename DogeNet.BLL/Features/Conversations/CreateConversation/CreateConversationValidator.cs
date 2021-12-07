// <copyright file="CreateConversationValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.CreateConversation
{
    using DogeNet.BLL.Features.Account;
    using DogeNet.DAL;
    using FluentValidation;

    public class CreateConversationValidator : AbstractValidator<CreateConversationModel>
    {
        public CreateConversationValidator(DBContext db)
        {
            this.RuleFor(enitity => enitity.CreatorId).NotEmpty().NotNull()
                .Must(id => AccountChecks.UserIdValid(db, id)).WithMessage("Sender not found");
            this.RuleFor(enitity => enitity.SecondUserId).NotEmpty().NotNull().NotEqual(entity => entity.CreatorId)
                .Must(id => AccountChecks.UserIdValid(db, id)).WithMessage("Reciever not found");
            this.RuleFor(enitity => enitity.AvatarImg).NotEmpty();
        }
    }
}
