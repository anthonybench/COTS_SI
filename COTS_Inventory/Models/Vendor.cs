using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COTS_Inventory.Models
{
    public class Vendor
    {
        // Primary Key
        public int Id { get; set; }

        // Non-Key Columns
        [Required]
        [StringLength(100, ErrorMessage = "Oops! Name must not exceed 100 characters.")]
        public string Name { get; set; }
        [StringLength(20, ErrorMessage = "Oops! Phone must not exceed 20 characters.")]
        public string Phone { get; set; }
        [StringLength(50, ErrorMessage = "Oops! Email must not exceed 50 characters.")]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "Oops! Website must not exceed 50 characters.")]
        public string Website { get; set; }
        [StringLength(50, ErrorMessage = "Oops! Customer representative must not exceed 50 characters.")]
        public string CustomerRep { get; set; }
    }
}
