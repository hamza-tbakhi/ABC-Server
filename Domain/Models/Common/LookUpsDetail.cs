using System;
using System.Collections.Generic;

namespace Domain.Models.Common
{
    public partial class LookUpsDetail
    {
        public int Id { get; set; }
        public int MasterCode { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int OrderNumber { get; set; }

        public virtual LookUpsMaster MasterCodeNavigation { get; set; }
    }
}
