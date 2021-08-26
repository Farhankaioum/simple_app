using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Foundation.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(160)]
        public string ImageUrl { get; set; }

        [MaxLength(150)]
        public string FullName { get; set; }

        public ApplicationUser()
                    : base()
        { }

        internal ApplicationUser(string userName)
            : base(userName)
        { }
    }
}
