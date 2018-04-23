using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using T611370_CS.Models;

namespace T611370_CS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Model"] == null)
                Session["Model"] = InMemoryModel.GetGridModel();
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial() {
            return PartialView("_GridViewPartial", Session["Model"]);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(T611370_CS.Models.InMemoryModel item) {
            ViewData["EditError"] = "CRUD opearations are not implemented";
            return PartialView("_GridViewPartial", Session["Model"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(T611370_CS.Models.InMemoryModel item) {
            ViewData["EditError"] = "CRUD opearations are not implemented";
            return PartialView("_GridViewPartial", Session["Model"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 ID) {
            ViewData["EditError"] = "CRUD opearations are not implemented";
            return PartialView("_GridViewPartial", Session["Model"]);
        }
    }
}