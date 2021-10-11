using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Investeer.Models.Models
{
    public class PropertyName
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Column { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }
    }
}
