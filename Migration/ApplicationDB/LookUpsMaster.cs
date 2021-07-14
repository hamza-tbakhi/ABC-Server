using System;
using System.Collections.Generic;

#nullable disable

namespace Migration.ApplicationDB
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
