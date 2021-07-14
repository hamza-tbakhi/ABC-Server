using System;
using System.Collections.Generic;

#nullable disable

namespace Migration.ApplicationDB
{
    public partial class ApplicationException
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string LoggedInUser { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
