using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDo.Controllers
{
    public class TodoController : Controller
    {
        public ISampleDataService service { get; set; }
        // GET: Todo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JsonSample()
        {
            var result = service.AllSample();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}