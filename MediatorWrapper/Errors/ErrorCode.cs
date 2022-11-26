using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorWrapper.Errors
{
    public class ErrorCode
    {
        public const string ValidationError = "VALIDATION_ERROR";
        public const string InternalServerError = "INTERNAL_SERVER_ERROR";
        public const string ItemNotFound = "ITEM_NOT_FOUND";
        public const string ObjectExists = "OBJECT_EXIST";
    }
}
