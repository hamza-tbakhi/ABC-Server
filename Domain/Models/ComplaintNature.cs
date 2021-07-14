using Domain.Models.Common;
using System;
using System.Collections.Generic;



namespace Domain.Models
{
    public partial class ComplaintNature : BaseModel
    {
        public int ComplaintId { get; set; }
        public int ComplaintNatueId { get; set; }

        public virtual Complaint Complaint { get; set; }
    }
}
