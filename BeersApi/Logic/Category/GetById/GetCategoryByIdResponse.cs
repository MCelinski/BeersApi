using BeersApi.Models.Entities;
using MediatorWrapper.Models;

namespace BeersApi.Logic.Category.GetById
{

    public class GetCategoryByIdResponse : ResponseBase
    {
        public Models.Entities.Category Category { get; set; }
    }
}