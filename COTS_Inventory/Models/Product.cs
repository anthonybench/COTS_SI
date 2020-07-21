using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COTS_Inventory.Models
{
    public class Product
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Key
        [ForeignKey("Vendor")]
        [Display(Name = "Vendor Id")]
        public int SV_Id { get; set; }

        // Non-Key Columns
        [Required]
        [StringLength(25, ErrorMessage = "Oops! Name must not exceed 25 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Oops! Version must not exceed 20 characters.")]
        public string Version { get; set; }
        [StringLength(20, ErrorMessage = "Oops! Vendor category number must not exceed 20 characters.")]
        public string VendorCatNum { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Oops! Description must not exceed 100 characters.")]
        public string Description { get; set; }
        [StringLength(25, ErrorMessage = "Oops! NPR classification must not exceed 25 characters.")]
        public string NPRClassification { get; set; }
        [StringLength(10, ErrorMessage = "Oops! Safey critical status must not exceed 10 characters.")]
        public string SafetyCriticalDetermine {get; set;}

        // Navigation Property
        public Vendor Vendor { get; set; }
    }
}
