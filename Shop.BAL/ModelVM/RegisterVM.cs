using System.ComponentModel.DataAnnotations;

namespace Shop.BAL.ModelVM
{

    //userName - passWord - ConfirmPass  -  address -city
    public class RegisterVM
    {
        [Required(ErrorMessage = "Full Name is Requierd")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "UserName is Requierd")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Requierd")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password Dosn't Match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

    }
}
