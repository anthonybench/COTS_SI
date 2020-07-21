using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COTS_Inventory.Models
{
    public class ClientMachine
    {
        // Primary Key
        public int Id { get; set; }

        // Non-Key Columns
        [Required]
        [StringLength(64, ErrorMessage = "Oops! Name must not exceed 64 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Oops! Location must not exceed 25 characters.")]
        public string Location { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Oops! Owner must not exceed 30 characters.")]
        public string Owner { get; set; }
        [StringLength(30, ErrorMessage = "Oops! Security plan must not exceed 30 characters.")]
        public string ITSecurityPlan { get; set; }
        [StringLength(30, ErrorMessage = "Oops! Active status must not exceed 30 characters.")]
        public string Active { get; set; }
    }
}
