using MediatorWrapper.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorWrapper.HttpMediation
{
    public class HttpResponseMapperFactory : IHttpResponseMapperFactory
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public HttpResponseMapperFactory(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public IHttpResponseMapper<TResponse> Create<TResponse>()
            where TResponse : ResponseBase
        {
            using var services = this.serviceScopeFactory.CreateScope();
            return services.ServiceProvider.GetService<IHttpResponseMapper<TResponse>>();
        }
    }
}
