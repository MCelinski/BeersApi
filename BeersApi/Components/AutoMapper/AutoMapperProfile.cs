using AutoMapper;
using BeersApi.Logic.Brewery.Post;
using BeersApi.Logic.Category.Post;
using BeersApi.Models.Entities;

namespace BeersApi.Components.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            this.CreateMap<PostCategoryRequest, Category>();
            this.CreateMap<PostBreweryRequest,Brewery>();
           
        }
    }
}
