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
            Models.Veterinarian.List model = new Models.Veterinarian.List();
            model.Pager.CurrentPage = 1;
            model.Pager.TotalPages = Business.Veterinarian.GetTotalPages(model.Pager.PageSize);
            model.Filters.VeterinarianSpeciality = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
            model.Veterinarians = Business.Veterinarian.GetVeterinariansFilteredAndPaged(model.Pager.CurrentPage, model.Pager.PageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Models.Veterinarian.List model)
        {
            model.Pager.TotalPages = Business.Veterinarian.GetTotalPages(model.Pager.PageSize, model.Filters.Keyword);
            model.Pager.CurrentPage = (model.Pager.TotalPages < model.Pager.CurrentPage || model.Filters.FilterModified) ? 1 : model.Pager.CurrentPage;
            model.Filters.VeterinarianSpeciality = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
            model.Filters.FilterModified = false;
            model.Veterinarians = Business.Veterinarian.GetVeterinariansFilteredAndPaged(model.Pager.CurrentPage, model.Pager.PageSize, model.Filters.Keyword, model.Filters.SelectedVeterinarianSpecialityId);
            return View(model);
        }

        public ActionResult Details(Refugio.Models.Shared.RequestById request)
        {
            Models.Veterinarian.Details model = new Models.Veterinarian.Details();
            model.GetValues(Business.Veterinarian.GetVeterinarianById(request.Id.Value));
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Refugio.Models.Shared.RequestById request)
        {
            Models.Veterinarian.Edit model = new Models.Veterinarian.Edit();
            model.VeterinarianSpeciality = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
            if (request.Id.HasValue)
            {
                model.GetValues(Business.Veterinarian.GetVeterinarianById(request.Id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.Veterinarian.Edit model)
        {
            DTO.Veterinarian veterinarian = new DTO.Veterinarian();
            model.SetValues(veterinarian);
            Business.Veterinarian.Save(veterinarian);
            return RedirectToAction("Details", new { id = model.Id });
        }
    }
}