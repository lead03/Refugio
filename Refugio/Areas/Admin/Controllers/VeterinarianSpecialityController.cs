using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Areas.Admin.Controllers
{
    public class VeterinarianSpecialityController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Models.VeterinarianSpeciality.List model = new Models.VeterinarianSpeciality.List();
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }

        public ActionResult SpecialityList(Refugio.Areas.Admin.Models.VeterinarianSpeciality.List model)
        {
            try
            {
                model.Pager.TotalPages = Business.VeterinarianSpeciality.GetTotalPages(model.Pager.PageSize, model.Filters.Keyword);
                model.Pager.CurrentPage = (model.Pager.TotalPages < model.Pager.CurrentPage) ? 1 : model.Pager.CurrentPage;
                model.Specialities = Business.VeterinarianSpeciality.GetVeterinarianSpecialitiesFilteredAndPaged(model.Pager.CurrentPage, model.Pager.PageSize, model.Filters.Keyword);
                return PartialView("~/Areas/Admin/Views/VeterinarianSpeciality/Partials/_List.cshtml", model);
            }
            catch (Exception)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorProcessingListing + ". " + Refugio.Resources.Languages.Global.TryAgainContactSupport, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Specialities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Specialities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Specialities/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Refugio.Models.Shared.RequestById request)
        {
            try
            {
                Models.VeterinarianSpeciality.Edit editModel = new Models.VeterinarianSpeciality.Edit();
                if (request != null && request.Id.HasValue)
                {
                    DTO.VeterinarianSpeciality veterinarianSpeciality = Business.VeterinarianSpeciality.GetVeterinarianSpecialityById(request.Id.Value);
                    if (veterinarianSpeciality == null)
                    {
                        throw new KeyNotFoundException(Refugio.Resources.Languages.Global.VeterinarianNotFoundById);
                    }
                    Business.Common.Map<DTO.VeterinarianSpeciality, Models.VeterinarianSpeciality.Edit>(veterinarianSpeciality, editModel);

                }
                editModel.ProfessionalsAssociated = Business.VeterinarianSpeciality.GetVeterinarianCountBySpecialityId(request.Id.Value);
                return View(editModel);
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorProcessingEdit + ". " + ex.Message, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Index");
            }
            catch
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorProcessingEdit + ". " + Refugio.Resources.Languages.Global.TryAgainContactSupport, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Specialities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Specialities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
