using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Investeer.Models.ViewModels
{
    public class PropertyViewModel
    {
        public int ID { get; set; }
        public string ListedBy { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }

        public string ListedPrice { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:P0}")]
        public string LoanRate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:P0}")]
        public string LoanReturn { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:P0}")]
        public string CashRate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:P0}")]
        public string CashReturn { get; set; }
    }
}
