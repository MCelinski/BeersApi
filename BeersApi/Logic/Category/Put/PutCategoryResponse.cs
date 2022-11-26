using MediatorWrapper.Models;

namespace BeersApi.Logic.Category.Put
{
    public class PutCategoryResponse : ResponseBase
    {
        public Models.Entities.Category Category { get; set; }
    }
}
