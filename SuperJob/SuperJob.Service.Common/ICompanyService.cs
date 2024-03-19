using SuperJob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJob.Service.Common
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();
    }
}
