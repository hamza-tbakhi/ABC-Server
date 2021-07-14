using Domain.Models.Common;
using Repository.UnitOfWork;
using Service.Interfaces.Common;
using System;


namespace Service.Services.Common
{
    public class ApplicationExceptionsService : IApplicationExceptionsService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;

        public ApplicationExceptionsService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }


        public Domain.Models.Common.ApplicationException WriteException(Exception ex)
        {
            try
            {

                Domain.Models.Common.ApplicationException oApplicationExceptions = new Domain.Models.Common.ApplicationException();

                oApplicationExceptions.ErrorMessage = !string.IsNullOrEmpty(ex.Message) ? ex.Message : string.Empty;
                oApplicationExceptions.InnerException = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                oApplicationExceptions.StackTrace = ex.StackTrace;
                oApplicationExceptions.DateTime = DateTime.Now;

                var result = _repositoryUnitOfWork.ApplicationExceptions.Value.WriteException(oApplicationExceptions);

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
