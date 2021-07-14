using System;
using System.Collections.Generic;

namespace Domain.Models.Common
{
    public partial class LookUpsMaster
    {
        public LookUpsMaster()
        {
            LookUpsDetails = new HashSet<LookUpsDetail>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LookUpsDetail> LookUpsDetails { get; set; }
    }
}
