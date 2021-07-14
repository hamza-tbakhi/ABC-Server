using System;
using System.Collections.Generic;

#nullable disable

namespace Migration.ApplicationDB
{
    public partial class ComplaintNature
    {
        public int Id { get; set; }
        public int ComplaintId { get; set; }
        public int ComplaintNatueId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Complaint Complaint { get; set; }
    }
}
