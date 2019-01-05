using CExplorerService.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CExplorerService.WebAPI.Repositories.Base
{
    public interface IRepository<T> where T : EntityBase
    {
    }
}
