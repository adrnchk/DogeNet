// <copyright file="EditMessageValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.EditMessage
{
    using DogeNet.DAL;
    using FluentValidation;

    public class EditMessageValidator : AbstractValidator<EditMessageModel>
    {
        public EditMessageValidator(DBContext db)
        {
            this.RuleFor(entity => entity.Text).NotNull().NotEmpty();
            this.RuleFor(entity => entity.MessageId).NotNull().NotEmpty()
                .Must(id => MessageChecks.MessageIdValid(db, id)).WithMessage("Message not found");
        }
    }
}
