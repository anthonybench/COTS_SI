using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COTS_Inventory.Models
{
    public class Install
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Keys
        [ForeignKey("ClientMachine")]
        [Display(Name = "Client Machine Id")]
        public int CM_Id { get; set; }
        [ForeignKey("License")]
        [Display(Name = "Software License Id")]
        public int SL_Id { get; set; }

        // Non-Key Columns
        public string SerialNumber { get; set; }
        public string Comment { get; set; }

        // Navigation Properties
        public ClientMachine ClientMachine { get; set; }
        public License License { get; set; }
    }
}
