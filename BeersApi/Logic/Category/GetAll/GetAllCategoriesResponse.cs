using BeersApi.Models.Entities;
using MediatorWrapper.Models;
using System.Collections.Generic;

namespace BeersApi.Logic.Category.GetAll
{
    public class GetAllCategoriesResponse : ResponseBase
    {
        public IEnumerable <Models.Entities.Category> Categories { get; set; }
    }
}
