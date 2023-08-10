using Microsoft.AspNetCore.Identity;
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public List<News> News { get; set; }
        [PersonalData]
        public List<Property> Properties { get; set; }
        [PersonalData]
        public byte[] ProfileImage { get; set; }

    }
}
