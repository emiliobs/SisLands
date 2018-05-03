using System.ComponentModel.DataAnnotations;

namespace SisLands.Backend.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SisLands.Domain;

    [NotMapped]
    public class UserView  : User
    {

        //[Display (Name= "Picture")]
        //public HttpPostedFileBase PictureFile { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(20, ErrorMessage = "The length for field {0} must be betwen {1} and {2} characteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Display (Name = "PAssword Confirm")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(20, ErrorMessage = "The length for field {0} must be betwen {1} and {2} characteres", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "The password and confirm does no match.")]
        public string PasswordConfirm { get; set; }


    }
}