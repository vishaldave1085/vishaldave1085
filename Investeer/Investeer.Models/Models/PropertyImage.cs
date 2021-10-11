using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Investeer.Models.Models
{
    public class PropertyImage
    {
        [Key]
        public int ID { get; set; }

        public virtual int PropertyDetailId { get; set; }

        [ForeignKey("PropertyDetailId")]
        public virtual PropertyDetail PropertyDetail { get; set; }

        public string ImageUrl { get; set; }
    }
}
