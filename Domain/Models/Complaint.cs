using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public partial class Complaint : BaseModel
    {
        public Complaint()
        {
            ComplaintNatures = new HashSet<ComplaintNature>();
        }

        public DateTime ComplaintDate { get; set; }
        public string ComplainerName { get; set; }
        public string ComplainerEmail { get; set; }
        public string ComplaintLocation { get; set; }
        public string ComplaintDetails { get; set; }
        public string DesiredOutcome { get; set; }
        public int Status { get; set; }
        public bool? NoPromotion { get; set; }

        [NotMapped]
        public bool? CanEdit { get; set; }

        public virtual ICollection<ComplaintNature> ComplaintNatures { get; set; }
    }
}
