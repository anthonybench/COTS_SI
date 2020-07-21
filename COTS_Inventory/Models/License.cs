using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COTS_Inventory.Models
{
    public class License
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Key
        [ForeignKey("Product")]
        [Display(Name = "Product Id")]
        public int SP_Id { get; set; }

        // Non-Key Columns
        [Required]
        [StringLength(25, ErrorMessage = "Oops! Type must not exceed 25 characters.")]
        public string Type { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Oops! Servicer must not exceed 30 characters.")]
        public string Servicer { get; set; }
        public int NumOfInstalls { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Oops! Cost must not exceed 25 characters.")]
        public string Cost { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Oops! Purchase order # must not exceed 25 characters.")]
        public string PurchaseOrderNum { get; set; }
        [StringLength(25, ErrorMessage = "Oops! MR # must not exceed 25 characters.")]
        public string MRNumber { get; set; }
        [StringLength(30, ErrorMessage = "Oops! Purchase agent must not exceed 30 characters.")]
        public string PurchaseAgent { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Oops! Owner must not exceed 30 characters.")]
        public string Owner { get; set; }
        [StringLength(50, ErrorMessage = "Oops! Owner Email must not exceed 50 characters.")]
        public string OwnerEmail { get; set; }
        [StringLength(50, ErrorMessage = "Oops! Activation website must not exceed 50 characters.")]
        public string ActivationWebsite { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Oops! Contract # must not exceed 50 characters.")]
        public string ContractNumber { get; set; }
        public string Comment { get; set; }

        // Navigation Property
        public Product Product { get; set; }
    }
}
