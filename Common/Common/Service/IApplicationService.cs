using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service
{
    public interface IApplicationService<t, tfilter> where t : class where tfilter : class
    {
        Task<IEnumerable<t>> GetWithFilter(tfilter filters);
        Task<t> GetById(Guid id);
        Task Insert(t usuario);
        Task Update(t usuario);
        Task Delete(Guid id);
    }
}
