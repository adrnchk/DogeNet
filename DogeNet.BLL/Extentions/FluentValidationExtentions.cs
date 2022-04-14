// <copyright file="FluentValidationExtentions.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Extentions
{
    using FluentValidation;

    public static class FluentValidationExtentions
    {
        public static IRuleBuilderOptions<T, TProperty> NotFound<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
        {
            var type = typeof(T);
            return rule.WithMessage("{type} entity is not found");
        }
    }
}