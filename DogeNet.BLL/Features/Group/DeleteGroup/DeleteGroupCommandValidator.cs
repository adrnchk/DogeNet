// <copyright file="DeleteGroupValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.DeleteGroup
{
    using DogeNet.DAL;
    using FluentValidation;

    public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
    {
        public DeleteGroupCommandValidator(DBContext db)
        {
            this.RuleFor(entity => entity.id).NotNull().Must(id => GroupChecks.DoesGroupExist(db, id)).WithMessage("Group not found");
        }
    }
}
