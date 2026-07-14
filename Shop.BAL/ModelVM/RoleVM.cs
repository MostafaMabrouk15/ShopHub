using System.ComponentModel.DataAnnotations;

namespace Shop.BAL.ModelVM
{
    public class RoleVM
    {

        [Required(ErrorMessage = "Role is Required")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
