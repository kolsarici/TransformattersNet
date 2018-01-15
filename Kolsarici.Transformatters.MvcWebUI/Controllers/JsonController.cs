using Kolsarici.Transformatters.Business.Abstract;
using Kolsarici.Transformatters.Entities.Concrete;
using Kolsarici.Transformatters.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kolsarici.Transformatters.MvcWebUI.Controllers
{
    public class JsonController : Controller
    {
        private IJsonService _jsonService;
        public JsonController(IJsonService jsonService)
        {
            _jsonService = jsonService;
        }
        public ActionResult Index()
        {
            var model = new BeautifyViewModel
            {
                Beautify = new Beautify()
            };
            return View(model);
        }

        public ActionResult Root()
        {
            return RedirectToAction("Index", "Json");
        }

        public ActionResult Converted(Beautify b)
        {
            var model = new BeautifyViewModel
            {
                Beautify = b
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Beautify beautify)
        {
            //burda beautify in dolu gelmesi _ViewImport un oluşturulmasıyla oldu
            var bb = new Beautify();
            bb.Str = beautify.Str;
            bb.BeautifiedStr = _jsonService.Beautify(beautify.Str);

            return RedirectToAction("Converted", bb);
        }

        [HttpGet]
        public JsonResult BeautifyInNewPage(Beautify beautify)
        {
            var a = _jsonService.Desrialize(beautify.Str);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}