﻿using BlazorDiscoveryAPI.Application.Base;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BlazorDiscoveryAPI.Application
{
    public class FailFastValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : BaseResult
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest command, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Count == 0
                ? next()
                : FormatErrorsToResponse(failures);
        }

        private static Task<TResponse> FormatErrorsToResponse(IEnumerable<ValidationFailure> failures)
        {
            BaseResult response = new(failures.Select(x => new Error(CommonErrors.ERRO_VALIDACAO, x.ErrorMessage)));

            return Task.FromResult((response as TResponse)!);
        }
    }
}
