// <copyright file="DeleteGroupValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.DeleteGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
