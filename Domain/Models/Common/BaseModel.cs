using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
