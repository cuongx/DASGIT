using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAS.Web.Models;
using DAS.Domain.Resquests;
using DAS.Web.Common;
using DAS.Domain.Responses;
using DAS.Domain.Responses.Books;
using DAS.Domain.Resquests.Author;

namespace DAS.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            ViewBag.Title = "Index Books";
            var category = new Category();
            category = ApiHelper<Category>.HttpGetAsync($"{Helper.ApiUrl}category/get/{id}");
            if(category != null)
            {
                ViewBag.Categorys = category;           
            }
            return View();     
        }
        //public IActionResult List(int id)
        //{
        //    ViewBag.Title = "Index Books";
        //    var author = new Author();
        //    author = ApiHelper<Author>.HttpGetAsync($"{Helper.ApiUrl}author/get/{id}");
        //    if (author != null)
        //    {               
        //        ViewBag.Authors = author;
        //    }
        //    return View();
        //}
        public JsonResult Gets(int id)
        {
            var books = new List<Bookss>();
            books = ApiHelper<List<Bookss>>.HttpGetAsync($"{Helper.ApiUrl}book/gets/{id}");
            return Json(new { books });
        }

        [Route("/Book/Get/{id}")]
        public JsonResult Get(int id)
        {
            var books = new Bookss();
            books = ApiHelper<Bookss>.HttpGetAsync($"{Helper.ApiUrl}book/get/{id}");
            return Json(new { books });
        }

        public JsonResult Save([FromBody] SaveBooksRequest model)
        {
            var books = new SaveAuthorResult();
            books = ApiHelper<SaveAuthorResult>.HttpPostAsync($"{Helper.ApiUrl}book/save", model);
            return Json(new { books });
        }
         public JsonResult Delete(int id)
         {
                var books = new DeleteBooksResult();
                books = ApiHelper<DeleteBooksResult>.HttpGetAsync($"{Helper.ApiUrl}book/delete/{id}", "DELETE");
                return Json(new { books });
            
          } 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
