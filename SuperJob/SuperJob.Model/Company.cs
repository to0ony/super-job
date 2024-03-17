using SuperJob.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJob.Model
{
    public class Company : ICompany
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public Guid OwnerId { get; set; }
    }
}
