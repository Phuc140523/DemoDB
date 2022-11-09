using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;
namespace DemoDB.Controllers
{
    public class CategoryController : Controller
    {
        DBSportStoreEntities database =new DBSportStoreEntities();
        // GET: Category
        public PartialViewResult CategoryPartial()
        {
            var cateList = database.Categories.ToList();
            return PartialView(cateList);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}