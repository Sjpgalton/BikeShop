using System.ComponentModel.DataAnnotations;

namespace Redweb.BikeShop.Core.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}