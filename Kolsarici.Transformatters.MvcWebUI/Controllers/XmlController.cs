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
    [ValidateInput(false)]
    public class XmlController : Controller
    {
        private IXmlService _xmlService;
        public XmlController(IXmlService xmlService)
        {
            _xmlService = xmlService;
        }

        
        public ActionResult Index()
        {
            var model = new BeautifyViewModel
            {
                Beautify = Session["BeautifiedObject"] == null ? new Beautify() : ((Beautify)Session["BeautifiedObject"])
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Beautify beautify)
        {
            //burda beautify in dolu gelmesi _ViewImport un oluşturulmasıyla oldu
            var bb = new Beautify();
            bb.Str = beautify.Str;
            bb.BeautifiedStr = _xmlService.Beautify(beautify.Str);
            Session.Add("BeautifiedObject", bb);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BeautifyInNewPage(Beautify beautify)
        {
            if (beautify.Str == null)
            {
                beautify.Str = "";
            }
            return Content(beautify.Str, "text/xml");
        }
    }
}