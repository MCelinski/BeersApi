using MediatorWrapper.Errors;
using MediatorWrapper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Linq;

namespace BeersApi.Components.Infrastructure
{
    public abstract class HttpResponseMapperBase
    {
        /// <summary>
        /// MapErrors method for mapping error codes to response.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected virtual IActionResult MapErrors(ResponseBase response)
        {
            var errorCodes = response.Errors.Select(err => err.Code).First();

            switch (errorCodes)
            {
                case ErrorCode.InternalServerError:
                    return new ObjectResult(new { errors = response.Errors })
                    {
                        StatusCode = (int)HttpStatusCode.BadGateway,
                    };

                case ErrorCode.ValidationError:
                    return new ObjectResult(new { errors = response.Errors })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                    };

                case ErrorCode.ItemNotFound:
                    return new ObjectResult(new { errors = response.Errors })
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                    };
                case ErrorCode.ObjectExists:
                    return new ObjectResult(new { errors = response.Errors })
                    {
                        StatusCode = (int)HttpStatusCode.Conflict,
                    };

                default:
                    throw new InvalidOperationException("Error type unknown");
            }
        }
    }
}
