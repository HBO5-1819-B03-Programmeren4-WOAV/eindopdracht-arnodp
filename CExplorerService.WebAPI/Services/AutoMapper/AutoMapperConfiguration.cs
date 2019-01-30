using AutoMapper;
using CExplorerService.lib.DTO;
using CExplorerService.lib.Models;

namespace CExplorerService.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile") { }
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<CocktailBasic, Cocktail>();

            CreateMap<Ingredient, IngredientBasic>();
                //.ForMember(dest => dest.name,
                //opts => opts.MapFrom(src => src.IngredientBase.Name));

            CreateMap<Cocktail, CocktailWithOrigin>()
                .ForMember(dest => dest.Origin,
                opts => opts.MapFrom(scr => scr.Origin.Country));

            CreateMap<Cocktail, CocktailDetailed>()
                .ForMember(dest => dest.origin,
                opts => opts.MapFrom(src => src.Origin.Country))
                .ForMember(dest => dest.Ingredients,
                opts => opts.MapFrom(src => src.Ingredients));
        }
    }
}
