using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repository;
using Repository.Context;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Interfaces.Common;
using Service.Services;
using Service.Services.Common;
using System;

namespace Service.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly LoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public Lazy<IApplicationExceptionsService> ApplicationExceptions { get; set; }
        public Lazy<IAuthService> Auth { get; set; }
        public Lazy<IUserService> User { get; set; }
        public Lazy<IComplaintService> Complaint { get; set; }

        public ServiceUnitOfWork(ApplicationContext context , UserManager<ApplicationUser> userManager,IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _repositoryUnitOfWork = new RepositoryUnitOfWork(context);
            _loggedInUserService = new LoggedInUserService(httpContextAccessor);
            _mapper = mapper;

            ApplicationExceptions = new Lazy<IApplicationExceptionsService>(() => new ApplicationExceptionsService(_repositoryUnitOfWork));
            Auth = new Lazy<IAuthService>(() => new AuthService(userManager, _repositoryUnitOfWork, signInManager, _loggedInUserService, mapper));
            User = new Lazy<IUserService>(() => new UserService(userManager, _repositoryUnitOfWork, _loggedInUserService, _mapper));
            Complaint = new Lazy<IComplaintService>(() => new ComplaintService(userManager, _repositoryUnitOfWork, _loggedInUserService));
        }

        public void Dispose() { }
    }
}
