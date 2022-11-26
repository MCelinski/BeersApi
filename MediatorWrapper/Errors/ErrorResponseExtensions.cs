using MediatorWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatorWrapper.Errors
{
    public static class ErrorResponseExtensions
    {

        public static TResponse CreateErrorResponse<TResponse>(this string code, string title = null, string detail = null)
            where TResponse : ResponseBase
        {
            return new ErrorModel(code, title, detail).CreateErrorResponse<TResponse>();
        }

     
        public static TResponse CreateErrorResponse<TResponse>(this ErrorModel errorModel)
            where TResponse : ResponseBase
        {
            return new[] { errorModel }.CreateErrorResponse<TResponse>();
        }

        public static TResponse CreateErrorResponse<TResponse>(this IEnumerable<ErrorModel> models)
            where TResponse : ResponseBase
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Errors = models;
            return response;
        }

        public static TResponse CreateErrorResponse<TResponse>(this string code, IEnumerable<string> validationMessages, string title = null)
            where TResponse : ResponseBase
        {
            var failuresList = validationMessages as IList<string> ?? validationMessages?.ToList();

            if (failuresList == null || !failuresList.Any())
            {
                return code.CreateErrorResponse<TResponse>(title);
            }

            var errorModels = failuresList
                .Select(fail => new ErrorModel(code, title, fail));

            return errorModels.CreateErrorResponse<TResponse>();
        }
    }
}

