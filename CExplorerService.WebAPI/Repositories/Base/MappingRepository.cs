using AutoMapper;
using CExplorerService.lib.Models.Base;
using CExplorerService.WebAPI.Data;

namespace CExplorerService.WebAPI.Repositories.Base
{
    public class MappingRepository<T> : Repository<T> where T : EntityBase
    {
        protected readonly IMapper mapper;

        public MappingRepository(CExplorerServiceContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
    }
}
