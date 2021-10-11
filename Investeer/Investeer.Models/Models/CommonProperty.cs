using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Investeer.Models.Models
{
    public class CommonProperty
    {
        public virtual int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        public virtual string AddedBy { get; set; }

        [ForeignKey("AddedBy")]
        public virtual ApplicationUser User1 { get; set; }

        public DateTime? AddedDt { get; set; }

        public virtual string ModifiedBy { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual ApplicationUser User2 { get; set; }

        public DateTime? ModifiedDt { get; set; }
    }
}
