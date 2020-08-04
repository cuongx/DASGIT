using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS.Domain.Responses.Publishing;
using DAS.Domain.Resquests.Publishing;
using DAS.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DAS.Web.Controllers
{
    public class PublishingController : Controller
    {
        private readonly ILogger<PublishingController> logger;

        public PublishingController(ILogger<PublishingController> logger)
        {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Index Publishing";
            return View();
        }
        public JsonResult Gets()
        {
            var publishings = new List<Publishing>();
            publishings = ApiHelper<List<Publishing>>.HttpGetAsync($"{Helper.ApiUrl}publishing/gets");
            return Json(new { publishings });
        }
        [Route("punlishing/get/{id}")]
        public JsonResult Get(int id)
        {
            var publishings = new Publishing();
            publishings = ApiHelper<Publishing>.HttpGetAsync($"{Helper.ApiUrl}publishing/get{id}");
            return Json(new { publishings });
        }
        [Route("publishing/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var publishings = new DeletePublishingResult();
            publishings = ApiHelper<DeletePublishingResult>.HttpGetAsync($"{Helper.ApiUrl}publishing/delete/{id}");
            return Json(new { publishings });
        }
        public JsonResult Save([FromBody] SavePublishingResquest model)
        {
            var publishings = new SavePublishingResult();
            publishings = ApiHelper<SavePublishingResult>.HttpPostAsync($"{Helper.ApiUrl}publishing/save", model);
            return Json(new { publishings });
        }
    }
}