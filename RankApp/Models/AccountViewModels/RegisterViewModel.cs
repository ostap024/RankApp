using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RankApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ПІБ")]
        public string PIB { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "RegCode")]
        public string RegCode { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
