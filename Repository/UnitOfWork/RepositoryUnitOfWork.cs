using Domain.Models.Common;
using Repository.Context;
using Repository.Interfaces;
using Repository.Interfaces.Common;
using Repository.Repositories;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private ApplicationContext _context;

        public Lazy<IApplicationExceptionsRepository> ApplicationExceptions { get; set; }
        public Lazy<IUserRoleRepository> UserRoles { get; set; }
        public Lazy<IComplaintRepository> Complaint{ get; set; }
        public RepositoryUnitOfWork(ApplicationContext context)
        {
            _context = context;
            ApplicationExceptions = new Lazy<IApplicationExceptionsRepository>(() => new ApplicationExceptionsRepository(_context));
            UserRoles = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(_context));
            Complaint = new Lazy<IComplaintRepository>(() => new ComplaintRepository(_context));
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
