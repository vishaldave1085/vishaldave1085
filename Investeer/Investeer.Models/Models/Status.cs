using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investeer.Models.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Display(Name ="Status Name")]
        public string Name { get; set; }
    }
}
