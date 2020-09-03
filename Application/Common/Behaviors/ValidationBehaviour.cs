﻿using FluentValidation;
using MediatR;
using MyMoon.Application.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Common.Behaviors
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults
                    .SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .Select(f => new Error()
                    {
                        ErrorCode = f.ErrorCode,
                        ErrorMessage = f.ErrorMessage
                    })
                    .ToList();

                if (failures.Count != 0)
                {
                    TResponse response = new TResponse();
                    response.Errors.AddRange(failures);

                    return await Task.FromResult(response);
                }
            }
            return await next();
        }
    }
}
