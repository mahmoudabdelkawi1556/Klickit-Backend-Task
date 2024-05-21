using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var message = failures.Select(x => $"{x.PropertyName}" + ": " + x.ErrorMessage).FirstOrDefault();
                throw new ValidationException(message);
            }

            return next();
        }
    }
}
