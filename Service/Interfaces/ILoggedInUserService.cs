using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ILoggedInUserService
    {
        int GetUserId();
        List<string> GetUserRoles();
        string GetUserName();
    }
}
