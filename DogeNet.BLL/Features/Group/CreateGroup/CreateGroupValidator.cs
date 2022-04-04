// <copyright file="CreateGroupValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.CreateGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentValidation;

    public class CreateGroupValidator : AbstractValidator<CreateGroupModel>
    {
        public CreateGroupValidator()
        {
            this.RuleFor(enitity => enitity.Name).NotEmpty().NotNull().MinimumLength(GroupConstants.MinLengthForName)
                  .MaximumLength(GroupConstants.MaxLengthForName);
            this.RuleFor(enitity => enitity.Title).NotNull().MaximumLength(GroupConstants.MaxLengthForTitle);
            this.RuleFor(enitity => enitity.CreatorId).NotNull();
            this.RuleFor(enitity => enitity.StatusId).NotNull();
        }
    }
}
