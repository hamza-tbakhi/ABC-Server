using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service.Services
{
    public class ComplaintService : IComplaintService
    {
        private UserManager<ApplicationUser> _userManager;
        private ILoggedInUserService _loggedInUserService;
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public ComplaintService(
            UserManager<ApplicationUser> userManager,
            IRepositoryUnitOfWork repositoryUnitOfWork,
            ILoggedInUserService loggedInUserService)
        {
            _userManager = userManager;
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _loggedInUserService = loggedInUserService;
        }
        public Complaint Add(Complaint entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = _loggedInUserService.GetUserId().ToString();

            entity.ComplaintNatures.Select(x =>
            {
                x.CreationDate = DateTime.Now;
                x.CreatedBy = _loggedInUserService.GetUserId().ToString();
                return x;
            });

            Complaint Complaint = _repositoryUnitOfWork.Complaint.Value.Add(entity);
            return Complaint;
        }

        public Complaint Update(Complaint entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.ModifiedBy = _loggedInUserService.GetUserId().ToString();

            entity.ComplaintNatures.Select(x =>
            {
                x.ModificationDate = DateTime.Now;
                x.ModifiedBy = _loggedInUserService.GetUserId().ToString();
                return x;
            });

            Complaint Complaint = _repositoryUnitOfWork.Complaint.Value.Update(entity);
            return Complaint;
        }

        public IEnumerable<Complaint> UpdateRange(IEnumerable<Complaint> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Complaint> AddRange(IEnumerable<Complaint> entities)
        {
            IEnumerable<Complaint> Complaint = _repositoryUnitOfWork.Complaint.Value.AddRange(entities);
            return Complaint;
        }

        public Complaint Get(long Id)
        {
            int userId = _loggedInUserService.GetUserId();
            int userRoleId = _repositoryUnitOfWork.UserRoles.Value.FirstOrDefault(x => x.UserId == userId).RoleId;

            Complaint Complaint = _repositoryUnitOfWork.Complaint.Value.FirstOrDefault(x => x.Id == Id , i => i.ComplaintNatures);
            Complaint.CanEdit = userRoleId == RoleTypes.Admin.GetHashCode();

            return Complaint;
        }

        public IEnumerable<Complaint> GetAll()
        {
            IEnumerable<Complaint> Complaint = _repositoryUnitOfWork.Complaint.Value.GetAll();
            return Complaint;
        }

        public IEnumerable<Complaint> GetList()
        {
            int userId = _loggedInUserService.GetUserId();
            int userRoleId = _repositoryUnitOfWork.UserRoles.Value.FirstOrDefault(x => x.UserId == userId).RoleId;

            IEnumerable<Complaint> Complaint = _repositoryUnitOfWork.Complaint.Value.Find(x => (userRoleId == RoleTypes.Admin.GetHashCode()) || 
                                                                                               (userRoleId == RoleTypes.Client.GetHashCode() && x.CreatedBy == userId.ToString()),i => i.ComplaintNatures)
                                                                                     .ToList()
                                                                                     .Select(y =>
                                                                                    {
                                                                                        y.CanEdit = userRoleId == RoleTypes.Admin.GetHashCode();
                                                                                        return y;
                                                                                    });
            return Complaint;
        }

        public Complaint Remove(Complaint entity)
        {
            Complaint Complaint = _repositoryUnitOfWork.Complaint.Value.Remove(entity);
            return Complaint;
        }

        public IEnumerable<Complaint> RemoveRange(IEnumerable<Complaint> entities)
        {
            IEnumerable<Complaint> Complaint = _repositoryUnitOfWork.Complaint.Value.RemoveRange(entities);
            return Complaint;
        }

        public IEnumerable<Complaint> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


    }
}
