// <copyright file="GetGroupQueryValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DogeNet.DAL;
    using FluentValidation;

    public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
    {
        public GetGroupQueryValidator(DBContext db)
        {
            this.RuleFor(entity => entity.id).NotNull().Must(id => GroupChecks.PostIdValid(db, id)).WithMessage("Group not found");
        }
    }
}
