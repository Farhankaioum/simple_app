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

            try
            {
                string userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var users = _userManager.Users.Where(u => u.Email != userEmail);
                return Ok(users);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message, ex);
                return BadRequest();
            }
            
        }

        [HttpGet("GetUserByUserId")]
        public async Task<ActionResult> GetUserById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                    return NotFound("User not found");

                return Ok(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(RegisterModel registerModel)
        {
            try
            {
                var result = await _userService.RegisterAsync(registerModel);
                if (!result)
                    return Ok("Error occured!");

                return Ok("New User created!");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserDto userModel, string id)
        {
            try
            {
                var result = await _userService.UpdateUser(userModel, id);
                if (!result)
                    return BadRequest("Error occured!");

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            try
            {
                var result = await _userService.DeleteUser(userId);
                if (!result)
                    return Ok("Error occured!");

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
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
                return BadRequest();
            }
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
                return BadRequest();
            }
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
                return BadRequest();
            }
            
        }


        [HttpGet("GetAllBook")]
        public ActionResult GetAllBook()
        {
            try
            {
                var books = _bookService.GetAll();
                return Ok(books);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpGet("GetBookById")]
        public ActionResult GetBookById(Guid bookId)
        {
            try
            {
                var book = _bookService.GetById(bookId);
                return Ok(book);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPost("PostBook")]
        public ActionResult PostBook(Book book, string userId)
        {
            try
            {
                _bookService.Add(book, userId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPut("UpdateBook")]
        public ActionResult UpdateBook(Book book)
        {
            try
            {
                _bookService.Update(book);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBook")]
        public ActionResult DeleteBook(Guid bookId)
        {
            try
            {
                _bookService.Delete(bookId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpGet("GetAllArchive")]
        public ActionResult GetAllArchive()
        {
            try
            {
                var books = _bookService.GetAllArchiveBook();
                return Ok(books);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPost("archive")]
        public ActionResult Archive(BookParam param)
        {
            try
            {
                _bookService.Archive(param.BookId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPost("restore")]
        public ActionResult Restore(BookParam param)
        {
            try
            {
                _bookService.RestoreById(param.BookId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPost("restoreAll")]
        public ActionResult RestoreAll()
        {
            try
            {
                _bookService.RestoreAll();
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }
    }
}
