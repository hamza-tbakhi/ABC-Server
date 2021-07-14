using Service.Interfaces;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UnitOfWork
{
    public interface IServiceUnitOfWork : IDisposable
    {
        Lazy<IApplicationExceptionsService> ApplicationExceptions { get; set; }
        Lazy<IAuthService> Auth { get; set; }
        Lazy<IUserService> User { get; set; }
        Lazy<IComplaintService> Complaint { get; set; }
    }
}
