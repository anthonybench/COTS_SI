using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COTS_Inventory.Models
{
    public class Test
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Key
        [ForeignKey("Product")]
        [Display(Name = "Product Id")]
        public int SP_Id { get; set; }

        // Non-Key Columns
        [StringLength(25, ErrorMessage = "Oops! Test plan must not exceed 25 characters.")]
        public string TestPlan { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Oops! WA document must not exceed 25 characters.")]
        public string WEDocument { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TestDate { get; set; }
        [Required]
        public string PassResult { get; set; }

        // Navigation Property
        public Product Product { get; set; }
    }
}
