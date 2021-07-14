using System;
using System.Collections.Generic;

#nullable disable

namespace Migration.ApplicationDB
{
    public partial class Complaint
    {
        public Complaint()
        {
            ComplaintNatures = new HashSet<ComplaintNature>();
        }

        public int Id { get; set; }
        public DateTime ComplaintDate { get; set; }
        public string ComplainerName { get; set; }
        public string ComplainerEmail { get; set; }
        public string ComplaintLocation { get; set; }
        public string ComplaintDetails { get; set; }
        public string DesiredOutcome { get; set; }
        public int Status { get; set; }
        public bool? NoPromotion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<ComplaintNature> ComplaintNatures { get; set; }
    }
}
