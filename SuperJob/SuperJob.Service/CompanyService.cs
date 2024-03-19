using SuperJob.Model;
using SuperJob.Repository.Common;
using SuperJob.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJob.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(Guid companyId)
        {
            return await _companyRepository.GetByIdAsync(companyId);
        }

        public async Task<bool> CreateAsync(Company company)
        {
            return await _companyRepository.CreateAsync(company);
        }

        public async Task<bool> UpdateAsync(Guid companyId, Company updatedCompany)
        {
            return await _companyRepository.UpdateAsync(companyId, updatedCompany);
        }
    }
}
