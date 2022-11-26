using MediatorWrapper.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MediatorWrapper.HttpMediation
{
    public interface IHttpMediator
    {
        Task<IActionResult> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : ResponseBase;
    }
}
