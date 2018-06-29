using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RankApp.Data;

using System.ComponentModel.DataAnnotations;

namespace RankApp.Models.RegistrationViewModel
{
    public class RegistrationViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ПІБ")]
        public string PIB { get; set; }

        public string ReturnUrl { get; set; }
    }

}
