using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SearchModels
{
    public partial class UserSearchModel
    {
        public int RoleType { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public bool? IsActive { get; set; }
    }
}
