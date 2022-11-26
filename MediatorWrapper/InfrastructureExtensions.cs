using MediatorWrapper.HttpMediation;
using MediatorWrapper.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorWrapper
{
    public static class InfrastructureExtensions
    {
        public static void AddInternalMediatR(this IServiceCollection services)
        {
            services.AddSingleton<IHttpMediator, HttpMediator>();
            services.AddSingleton<IHttpResponseMapperFactory, HttpResponseMapperFactory>();
        }
    }
}
