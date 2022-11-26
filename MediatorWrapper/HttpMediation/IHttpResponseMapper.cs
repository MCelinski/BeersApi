using MediatorWrapper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorWrapper.HttpMediation
{
    public interface IHttpResponseMapper<in TResponse>
         where TResponse : ResponseBase
    {
        IActionResult Map(TResponse response);
    }
}
