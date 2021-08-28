using BookApp.API.Dtos;
using BookApp.API.Helpers;
using BookApp.Foundation.Entities;
using BookApp.Foundation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookApp.API.Controllers
{
    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IPermissionService _permissionService;
        private readonly PermissionHelper _permissionHelper;

        public BookController(UserManager<ApplicationUser> userManager,
                              IBookService bookService,
                              IPermissionService permissionService,
                              PermissionHelper permissionHelper) 
            : base(userManager)
        {
            _bookService = bookService;
            _permissionService = permissionService;
            _permissionHelper = permissionHelper;
        }

       [HttpGet()]
       public ActionResult Get(string userId)
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Get service not available");

            var books = _bookService.GetAll(userId);
            return Ok(books);
        }

        [HttpGet("GetById")]
        public ActionResult GetById(string userId, Guid bookId) 
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Get service not available");

            var book = _bookService.GetById(bookId, userId);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult Post(Book book, string userId)
        {
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

            _bookService.Add(book, userId);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Book book, string userId)
        {
            if (!_permissionHelper.IsEditPermission())
                return BadRequest("Edit service not available");

            _bookService.Update(book, userId);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(Guid bookId, string userId)
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Delete service not available");

            _bookService.Delete(bookId, userId);
            return Ok();
        }

        [HttpGet("GetAllArchive")]
        public ActionResult GetAllArchive(string userId)
        {
            if (!_permissionHelper.IsGetPermission())
                return BadRequest("Get service not available");

            var books = _bookService.GetAllArchiveBook(userId);
            return Ok(books);
        }

        [HttpPost("archive")]
        public ActionResult Archive(BookParam param)
        {
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

            _bookService.Archive(param.BookId, param.UserId);
            return Ok();
        }

        [HttpPost("restore")]
        public ActionResult Restore(BookParam param)
        {
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

            _bookService.RestoreById(param.BookId, param.UserId);
            return Ok();
        }

        [HttpPost("restoreAll")]
        public ActionResult RestoreAll(BookParam param)
        {
            if (!_permissionHelper.IsPostPermission())
                return BadRequest("Post service not available");

            _bookService.RestoreAll(param.UserId);
            return Ok();
        }
    }
}
