using Microsoft.AspNetCore.Identity;

namespace Shop.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        //add props
        //add methods
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
