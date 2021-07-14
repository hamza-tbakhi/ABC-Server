using Domain.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ComplaintRepository :  Repository<Complaint> , IComplaintRepository
    {
        private ApplicationContext _context;
        public ComplaintRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
