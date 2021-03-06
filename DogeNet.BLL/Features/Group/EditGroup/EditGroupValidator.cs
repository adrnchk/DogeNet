// <copyright file="EditGroupValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.EditGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DogeNet.DAL;
    using FluentValidation;

    public class EditGroupValidator : AbstractValidator<EditGroupModel>
    {
        public EditGroupValidator(DBContext db)
        {
            this.RuleFor(enitity => enitity.Name).NotEmpty().NotNull().MinimumLength(GroupConstants.MinLengthForName)
                 .MaximumLength(GroupConstants.MaxLengthForName);
            this.RuleFor(enitity => enitity.Title).NotNull().MaximumLength(GroupConstants.MaxLengthForTitle);
            this.RuleFor(enitity => enitity.Id).NotNull().Must(id => GroupChecks.DoesGroupExist(db, id)).WithMessage("Group not found"); ;
            this.RuleFor(enitity => enitity.StatusId).NotNull();
        }
    }
}
