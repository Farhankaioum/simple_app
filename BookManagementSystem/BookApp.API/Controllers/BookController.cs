using BookApp.Foundation.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    public class BookController : BaseController
    {

        public BookController(UserManager<ApplicationUser> userManager) 
            : base(userManager)
        {
        }

        [HttpGet]
        [Authorize()]
        public string Get()
        {
            return "ok";
        }
    }
}
