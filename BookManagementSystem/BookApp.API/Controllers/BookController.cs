using BookApp.API.Dtos;
using BookApp.API.Helpers;
using BookApp.Foundation.Entities;
using BookApp.Foundation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BookApp.API.Controllers
{
    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IPermissionService _permissionService;
        private readonly PermissionHelper _permissionHelper;
        private readonly ILogger<BookController> _logger;

        public BookController(UserManager<ApplicationUser> userManager,
                              IBookService bookService,
                              IPermissionService permissionService,
                              PermissionHelper permissionHelper,
                              ILogger<BookController> logger) 
            : base(userManager)
        {
            _bookService = bookService;
            _permissionService = permissionService;
            _permissionHelper = permissionHelper;
            _logger = logger;
        }

       [HttpGet()]
       public ActionResult Get(string userId)
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Get service not available");

            try
            {
                var books = _bookService.GetAll(userId);
                return Ok(books);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpGet("GetById")]
        public ActionResult GetById(string userId, Guid bookId) 
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Get service not available");

            try
            {
                var book = _bookService.GetById(bookId, userId);
                return Ok(book);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Post(Book book, string userId)
        {
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

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

        [HttpPut]
        public ActionResult Update(Book book, string userId)
        {
            if (!_permissionHelper.IsEditPermission())
                return BadRequest("Edit service not available");

            try
            {
                _bookService.Update(book, userId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult Delete(Guid bookId, string userId)
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Delete service not available");

            try
            {
                _bookService.Delete(bookId, userId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpGet("GetAllArchive")]
        public ActionResult GetAllArchive(string userId)
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Get service not available");

            try
            {
                var books = _bookService.GetAllArchiveBook(userId);
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
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

            try
            {
                _bookService.Archive(param.BookId, param.UserId);
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
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

            try
            {
                _bookService.RestoreById(param.BookId, param.UserId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }
        }

        [HttpPost("restoreAll")]
        public ActionResult RestoreAll(BookParam param)
        {
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

            try
            {
                _bookService.RestoreAll(param.UserId);
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
