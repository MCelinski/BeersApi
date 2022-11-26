using MediatorWrapper.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace MediatorWrapper.Models
{
    public abstract class ResponseBase
    {
        [JsonIgnore]
        public bool HasError => this.Errors != null && this.Errors.Any();

        public IEnumerable<ErrorModel> Errors { get; set; }
    }
}
