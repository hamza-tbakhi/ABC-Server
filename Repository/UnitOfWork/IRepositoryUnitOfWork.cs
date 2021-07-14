using Repository.Interfaces;
using Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
        Lazy<IApplicationExceptionsRepository> ApplicationExceptions { get; set; }
        Lazy<IUserRoleRepository> UserRoles { get; set; }
        Lazy<IComplaintRepository> Complaint { get; set; }

    }
}
