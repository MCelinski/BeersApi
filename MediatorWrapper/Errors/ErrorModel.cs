using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorWrapper.Errors
{
    public class ErrorModel
    {
        public ErrorModel(string code, string title = null, string detail = null)
        {
            this.Code = code;
            this.Title = title;
            this.Detail = detail;
        }

        public string Code { get; set; }

        public string Title { get; set; }


        public string Detail { get; set; }
    }
}
