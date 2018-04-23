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

        public ActionResult ExportTo(string OutputFormat) {
            var model = Session["Model"];

            switch (OutputFormat.ToUpper()) {
                case "PDF":
                    return GridViewExtension.ExportToPdf(GridViewHelper.ExportGridViewSettings, model);
                case "XLS":
                    return GridViewExtension.ExportToXls(GridViewHelper.ExportGridViewSettings, model);
                case "XLSX":
                    return GridViewExtension.ExportToXlsx(GridViewHelper.ExportGridViewSettings, model);
                default:
                    return RedirectToAction("Index");
            }
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

public static class GridViewHelper {
    private static GridViewSettings exportGridViewSettings;

    public static GridViewSettings ExportGridViewSettings {
        get {
            if (exportGridViewSettings == null)
                exportGridViewSettings = CreateExportGridViewSettings();
            return exportGridViewSettings;
        }
    }

    private static GridViewSettings CreateExportGridViewSettings() {
        GridViewSettings settings = new GridViewSettings();
        settings.Name = "GridView";
        settings.CallbackRouteValues = new { Controller = "Home", Action = "GridViewPartial" };
        settings.Width = Unit.Percentage(80);
        settings.KeyFieldName = "ID";
        settings.Columns.Add("ID");
        settings.Columns.Add("Text");
        settings.Columns.Add("Value1");
        settings.Columns.Add("Value2");
        return settings;
    }
}