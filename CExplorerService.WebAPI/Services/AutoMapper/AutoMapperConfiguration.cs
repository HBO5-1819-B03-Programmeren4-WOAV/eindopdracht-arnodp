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
        }
    }
}
