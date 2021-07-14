using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces.Common
{
    public interface IApplicationExceptionsRepository
    {
        public Domain.Models.Common.ApplicationException WriteException(Domain.Models.Common.ApplicationException ex);
       
    }
}
