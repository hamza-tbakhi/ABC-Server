using Domain.Models.Common;
using Repository.Context;
using Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.Common
{
    public class ApplicationExceptionsRepository : IApplicationExceptionsRepository
    {
        #region [Context]
        protected ApplicationContext Context;
        #endregion

        public ApplicationExceptionsRepository(ApplicationContext context)
        {
            Context = context;
        }

        public Domain.Models.Common.ApplicationException WriteException(Domain.Models.Common.ApplicationException ex)
        {
            Context.Set<Domain.Models.Common.ApplicationException>().Add(ex);
            Context.SaveChanges();
            Context.Entry(ex).GetDatabaseValues();

            return ex;
        }
    }
}
