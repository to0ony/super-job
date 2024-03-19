using SuperJob.Model;
using SuperJob.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperJob.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET api/values
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            try
            {
                var companies = await _companyService.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, companies);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{companyId}")]
        public async Task<HttpResponseMessage> GetByIdAsync(Guid companyId)
        {
            try
            {
                var company = await _companyService.GetByIdAsync(companyId);
                return Request.CreateResponse(HttpStatusCode.OK, company);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Company company)
        {
            try
            {
                var createdCompany = await _companyService.CreateAsync(company);
                return Request.CreateResponse(HttpStatusCode.Created, createdCompany);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        // PUT api/values/5
        [HttpPut]
        [Route("{companyId}")]
        public async Task<HttpResponseMessage> PutAsync(Guid companyId, [FromBody] Company updatedCompany)
        {
            try
            {
                await _companyService.UpdateAsync(companyId, updatedCompany);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
