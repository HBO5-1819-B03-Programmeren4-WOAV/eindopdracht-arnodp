using System.ComponentModel.DataAnnotations;

namespace CExplorer.MVC.Models
{
    public class LoginVm
    {
        [Required]
        [Display(Name = "E-mail")]
        public string EmailAdress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
