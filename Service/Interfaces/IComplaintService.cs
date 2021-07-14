using Domain.Models;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IComplaintService :IService<Complaint>
    {
        IEnumerable<Complaint> GetList();
    }
}
