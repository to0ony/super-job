using SuperJob.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJob.Repository.Common
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync();
    }
}
