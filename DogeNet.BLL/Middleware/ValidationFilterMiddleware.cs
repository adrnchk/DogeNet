// <copyright file="ValidationFilterMiddleware.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Middleware
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DogeNet.BLL.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class ValidationFilterMiddleware : IActionFilter
    {
        private readonly ILogger<ValidationFilterMiddleware> logger;

        public ValidationFilterMiddleware(ILogger<ValidationFilterMiddleware> logger) => this.logger = logger;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.logger.LogInformation(typeof(ValidationFilterMiddleware).Name, context.ModelState.Values);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage))
                .ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errors)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError,
                        };

                        errorResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}
