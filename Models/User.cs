using Microsoft.AspNetCore.Identity;

namespace Knigomaniq.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegisterOn { get; set; }
        public  ICollection<Shopping> Shoppings { get; set; }
    }
}