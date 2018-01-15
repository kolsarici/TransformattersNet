using Kolsarici.Transformatters.Business.Abstract;
using Kolsarici.Transformatters.Entities.Concrete;
using Kolsarici.Transformatters.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
                Beautify = Session["BeautifiedObject"] == null ? new Beautify() : ((Beautify)Session["BeautifiedObject"])
            };
            return View(model);
        }

        public ActionResult Root()
        {
            return RedirectToAction("Index", "Json");
        }

        [HttpPost]
        public ActionResult Index(Beautify beautify)
        {
            //burda beautify in dolu gelmesi _ViewImport un oluşturulmasıyla oldu
            var bb = new Beautify();
            bb.Str = beautify.Str;
            bb.BeautifiedStr = _jsonService.Beautify(beautify.Str);
            Session.Add("BeautifiedObject", bb);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult BeautifyInNewPage(Beautify beautify)
        {
            if (beautify.Str == null)
            {
                beautify.Str = "";
            }
            var a = new JavaScriptSerializer().DeserializeObject(beautify.Str);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}