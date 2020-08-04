using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using DAS.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS.Web.Controllers
{
    public class CategoryController:Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Index Category";
            return View();
        }
     
        public JsonResult Gets()
        {
            var categorys = new List<Category>();
            categorys = ApiHelper<List<Category>>.HttpGetAsync($"{Helper.ApiUrl}category/gets");
            return Json(new { categorys });
        }
       
        [Route("/Category/Get/{id}")]
        public JsonResult Get(int id)
        {
            var result = new Category();
            result = ApiHelper<Category>.HttpGetAsync($"{Helper.ApiUrl}category/get/{id}");
            return Json(new { result });
        }
      
        [Route("/category/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = new DeleteCategoryResult();
            result = ApiHelper<DeleteCategoryResult>.HttpGetAsync($"{Helper.ApiUrl}category/delete/{id}", "DELETE");
            return Json(new { result });
        }
        
        public JsonResult Save([FromBody] Category category)
        {
            var result = new SaveCategoryResult();
             result = ApiHelper<SaveCategoryResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}category/save",
                                                    category
                                                );
            return Json(new { result });
        }
    }
}
