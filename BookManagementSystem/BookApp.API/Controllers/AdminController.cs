using BookApp.API.Dtos;
using BookApp.API.Params;
using BookApp.Foundation.DTOs;
using BookApp.Foundation.Entities;
using BookApp.Foundation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookApp.API.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;
        private readonly ILogger<AuthController> _logger;

        public AdminController(UserManager<ApplicationUser> userManager,
                              IUserService userService,
                              IPermissionService permissionService,
                              IBookService bookService,
                              ILogger<AuthController> logger)
            : base(userManager)
        {
            _bookService = bookService;
            _userService = userService;
            _permissionService = permissionService;
            _logger = logger;
        }

        [HttpGet("GetAllUser")]
        public ActionResult GetAllUser()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var users = _userManager.Users.Where(u => u.Email != userEmail);
            return Ok(users);
        }

        [HttpGet("GetUserByUserId")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(RegisterModel registerModel)
        {
            var result = await _userService.RegisterAsync(registerModel);
            if (!result)
                return Ok("Error occured!");

            return Ok("New User created!");
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserDto userModel, string id)
        {
            var result = await _userService.UpdateUser(userModel, id);
            if (!result)
                return BadRequest("Error occured!");

            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            var result = await _userService.DeleteUser(userId);
            if (!result)
                return Ok("Error occured!");

            return Ok();
        }

        [HttpGet("AllActionPermission")]
        public async Task<ActionResult> GetAllActionPermission()
        {
            try
            {
                var allPermission = _permissionService.GetAll();
                return Ok(allPermission);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return BadRequest();
        }

        [HttpGet("GetPermissionById")]
        public async Task<ActionResult> GetPermissionById(int id)
        {
            try
            {
                var permission = _permissionService.GetById(id);
                return Ok(permission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return BadRequest();
        }

        [HttpPut("UpdatePermission")]
        public async Task<ActionResult> UpdatePermission(PermissionParams param)
        {
            try
            {
                _permissionService.UpdatePermission(param.Id, param.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return BadRequest();
        }


        [HttpGet("GetAllBook")]
        public ActionResult GetAllBook()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("GetBookById")]
        public ActionResult GetBookById(Guid bookId)
        {
            var book = _bookService.GetById(bookId);
            return Ok(book);
        }

        [HttpPost("PostBook")]
        public ActionResult PostBook(Book book, string userId)
        {
            _bookService.Add(book, userId);
            return Ok();
        }

        [HttpPut("UpdateBook")]
        public ActionResult UpdateBook(Book book)
        {
            _bookService.Update(book);
            return Ok();
        }

        [HttpDelete("DeleteBook")]
        public ActionResult DeleteBook(Guid bookId)
        {
            _bookService.Delete(bookId);
            return Ok();
        }

        [HttpGet("GetAllArchive")]
        public ActionResult GetAllArchive()
        {
            var books = _bookService.GetAllArchiveBook();
            return Ok(books);
        }

        [HttpPost("archive")]
        public ActionResult Archive(BookParam param)
        {
            _bookService.Archive(param.BookId);
            return Ok();
        }

        [HttpPost("restore")]
        public ActionResult Restore(BookParam param)
        {
            _bookService.RestoreById(param.BookId);
            return Ok();
        }

        [HttpPost("restoreAll")]
        public ActionResult RestoreAll()
        {
            _bookService.RestoreAll();
            return Ok();
        }
    }
}
