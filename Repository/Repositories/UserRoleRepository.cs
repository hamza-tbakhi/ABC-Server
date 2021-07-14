using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private ApplicationContext _context;
        public UserRoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserRole Add(UserRole entity)
        {
            _context.UserRoles.Add(entity);
            _context.SaveChanges();
            return entity;
        }
 
        public IEnumerable<UserRole> Find(Expression<Func<UserRole, bool>> predicate, params Expression<Func<UserRole, object>>[] navigationProperties)
        {
            IQueryable<UserRole> dbQuery = _context.Set<UserRole>();

            foreach (Expression<Func<UserRole, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<UserRole, object>(navigationProperty);
            }

            return dbQuery.Where(predicate).AsNoTracking();
        }

        public UserRole FirstOrDefault(Expression<Func<UserRole, bool>> where, params Expression<Func<UserRole, object>>[] navigationProperties)
        {
            UserRole result = _context.UserRoles.FirstOrDefault(where);
            return result;
        }
    }
}
