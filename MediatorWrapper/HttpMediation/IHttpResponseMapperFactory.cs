using MediatorWrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorWrapper.HttpMediation
{
    public interface IHttpResponseMapperFactory
    {
        IHttpResponseMapper<TResponse> Create<TResponse>()
            where TResponse : ResponseBase;
    }
}
