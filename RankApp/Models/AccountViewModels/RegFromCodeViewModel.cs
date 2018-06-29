using System.ComponentModel.DataAnnotations;
namespace RankApp.Models.AccountViewModels
{
    public class RegFromCodeViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Код реєстрації")]
        public string RegCode { get; set; }


    }
}
