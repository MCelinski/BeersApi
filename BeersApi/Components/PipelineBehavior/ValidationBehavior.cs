using FluentValidation;
using MediatorWrapper.Errors;
using MediatorWrapper.Models;
using MediatR;
using MediatorWrapper.HttpMediation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace BeersApi.Components.PipelineBehavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
       where TResponse : ResponseBase
    {
      
        private readonly IEnumerable<IValidator<TRequest>> validators;

     
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationTasks = this.validators
                .Select(v => v.ValidateAsync(context, cancellationToken))
                .ToList();

            await Task.WhenAll(validationTasks);

            var validationErrors = validationTasks
                .SelectMany(t => t.Result.Errors)
                .Where(err => err != null)
                .ToList();

            if (validationErrors.Count != 0)
            {
                foreach (var validationError in validationErrors)
                {
                    return ErrorCode.ValidationError.CreateErrorResponse<TResponse>(validationError.ToString());
                }
            }

            return await next();
        }
    }
}
