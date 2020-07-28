using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Account.Services.Models
{
   public class OperationsHistoryModel
    {
        [Required]
        public Guid FromAccount { get; set; }
        [Required]
        public Guid ToAccount { get; set; }
        [Required]
        [Range(1, 1000000)]
        public int Amount { get; set; }

    }
}
