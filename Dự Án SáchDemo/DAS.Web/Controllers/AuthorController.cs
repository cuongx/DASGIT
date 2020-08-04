using DAS.Domain.Responses.Author;
using DAS.Domain.Resquests.Author;
using DAS.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS.Web.Controllers
{
    public class AuthorController:Controller
    {
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }
       public IActionResult Index()
        {
            ViewBag.Title = "Index Author";
            return View();
        }
        public JsonResult Gets()
        {
            var authors = new List<Author>();
            authors = ApiHelper<List<Author>>.HttpGetAsync($"{Helper.ApiUrl}author/gets");
            return Json(new { authors });
        }

        [Route("author/get/{id}")]
        public JsonResult Get(int id)
        {
            var authors = new Author();
            authors = ApiHelper<Author>.HttpGetAsync($"{Helper.ApiUrl}author/get/{id}");
            return Json(new { authors });
        }
        [Route("author/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var authors = new DeleteAuthorResult();
            authors = ApiHelper<DeleteAuthorResult>.HttpGetAsync($"{Helper.ApiUrl}author/delete{id}");
            return Json(new { authors });
        }

        public JsonResult Save( [FromBody] SaveAuthorResquest model)
        {
            var authors = new SaveAuthorResult();
            authors = ApiHelper<SaveAuthorResult>.HttpPostAsync($"{Helper.ApiUrl}author/save",model);
            return Json(new { authors });
        }
    }
}
