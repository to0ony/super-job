using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJob.Model.Common
{
    public interface ICompany
    {
        Guid CompanyId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Address { get; set; }
        string EmailAddress { get; set; }
        string PhoneNumber { get; set; }
        DateTime CreationDate { get; set; }
        bool IsActive { get; set; }
        Guid OwnerId { get; set; }
    }
}
