using MediatorWrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorWrapper.HttpMediation
{
    public class HttpMediator : IHttpMediator
    {
        private readonly IMediator mediator;

        private readonly IHttpResponseMapperFactory httpResponseMapperFactory;

        public HttpMediator(IMediator mediator, IHttpResponseMapperFactory httpResponseMapperFactory)
        {
            this.mediator = mediator;
            this.httpResponseMapperFactory = httpResponseMapperFactory;
        }

        public async Task<IActionResult> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : ResponseBase
        {
            var response = await this.mediator.Send(request, cancellationToken);
            var responseMapper = this.httpResponseMapperFactory.Create<TResponse>();
            return responseMapper.Map(response);
        }
    }
}
