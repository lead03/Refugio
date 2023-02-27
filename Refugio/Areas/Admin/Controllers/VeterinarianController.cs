using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Areas.Admin.Controllers
{
    public class VeterinarianController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Models.Veterinarian.List model = new Models.Veterinarian.List();//sdsd
            model.Pager.CurrentPage = 1;
            model.Pager.TotalPages = Business.Veterinarian.GetTotalPages(model.Pager.PageSize);
            model.Veterinarians = Business.Veterinarian.GetAllVeterinariansPaged(model.Pager.CurrentPage, model.Pager.PageSize);
            return View(model);//asasas
        }

        [HttpPost]
        public ActionResult Index(Models.Veterinarian.List model)
        {
            model.Veterinarians = Business.Veterinarian.GetVeterinariansFilteredAndPaged(out int totalElements, model.Pager.CurrentPage, model.Pager.PageSize, model.Filters.Keyword);
            model.Pager.TotalPages = Business.Veterinarian.GetTotalPages(model.Pager.PageSize, totalElements);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            Models.Veterinarian.Details model = new Models.Veterinarian.Details();
            model.GetValues((DTO.Veterinarian)Business.Veterinarian.GetVeterinarianById(id));
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            Models.Veterinarian.Edit model = new Models.Veterinarian.Edit();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Edit()
        //{
        //    Models.Veterinarian.Edit model = new Models.Veterinarian.Edit();
        //    return View(model);
        //}
    }
}