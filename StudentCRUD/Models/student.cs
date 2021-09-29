using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentCRUD.Models
{
  public  interface Istudent
    {
         string Name { get; set; }
         string Address { get; set; }
         string Mobile { get; set; }
         string Email { get; set; }


    }
    public class student:Istudent
    {
        [Key]
        [Required(ErrorMessage ="Roll No Is Required")]
         public int RollNo { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Name length between 4 to 15")]
       // [DisplayName("Full Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Address length between 4 to 15")]
       // [ScaffoldColumn(false)]
       //[DisplayFormat(NullDisplayText ="Address Not Specified")]
       [ReadOnly(true)]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"\+91[0-9]{10}", ErrorMessage = "Mobile Invalid")]
        public string Mobile { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    

    }
}