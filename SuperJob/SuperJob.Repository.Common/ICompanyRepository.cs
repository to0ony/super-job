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
        Task<bool> CreateAsync(Company company);
        Task<bool> DeleteAsync(Guid companyId);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(Guid companyId);
        Task<bool> UpdateAsync(Guid companyId, Company updatedCompany);
    }
}
