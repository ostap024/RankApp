using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RankApp.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Логін")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }


        public string StatusMessage { get; set; }
    }
}
