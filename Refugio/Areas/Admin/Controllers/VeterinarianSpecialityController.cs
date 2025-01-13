using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
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

        public ActionResult Details(Refugio.Models.Shared.RequestById request)
        {
            try
            {
                Models.VeterinarianSpeciality.Details detailsModel = new Models.VeterinarianSpeciality.Details();
                if (request.Id.HasValue)
                {
                    DTO.VeterinarianSpeciality veterinarianSpeciality = Business.VeterinarianSpeciality.GetById(request.Id.Value);
                    if (veterinarianSpeciality == null)
                    {
                        throw new KeyNotFoundException(Refugio.Resources.Languages.Global.VeterinarianSpecialityNotFound);
                    }
                    Business.Common.Map<DTO.VeterinarianSpeciality, Models.VeterinarianSpeciality.Details>(veterinarianSpeciality, detailsModel);
                    detailsModel.ProfessionalsAssociatedCount = Business.VeterinarianSpeciality.GetVeterinarianCountBySpecialityId(request.Id.Value);
                    return View(detailsModel);
                }
                else
                {
                    throw new KeyNotFoundException(Refugio.Resources.Languages.Global.IdNotProvided);
                }
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorDisplayingDetails + ". " + ex.Message, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Index");
            }
            catch
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorDisplayingDetails + ". " + Refugio.Resources.Languages.Global.TryAgainContactSupport, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Index");
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
                    DTO.VeterinarianSpeciality veterinarianSpeciality = Business.VeterinarianSpeciality.GetById(request.Id.Value);
                    if (veterinarianSpeciality == null)
                    {
                        throw new KeyNotFoundException(Refugio.Resources.Languages.Global.VeterinarianSpecialityNotFound);
                    }
                    Business.Common.Map<DTO.VeterinarianSpeciality, Models.VeterinarianSpeciality.Edit>(veterinarianSpeciality, editModel);
                    editModel.ProfessionalsAssociatedCount = Business.VeterinarianSpeciality.GetVeterinarianCountBySpecialityId(request.Id.Value);
                }
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
        public ActionResult Edit(Models.VeterinarianSpeciality.Edit editRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(editRequest);
                }
                DTO.VeterinarianSpeciality veterinarianSpeciality = new DTO.VeterinarianSpeciality();
                if (!editRequest.IsNewSpeciality){
                    veterinarianSpeciality = Business.VeterinarianSpeciality.GetById(editRequest.Id);
                    Business.Common.CheckRowVersion(editRequest.RowVersion, veterinarianSpeciality.RowVersion);
                }
                Business.Common.Map<Models.VeterinarianSpeciality.Edit, DTO.VeterinarianSpeciality>(editRequest, veterinarianSpeciality);
                editRequest.Id = Business.VeterinarianSpeciality.Save(veterinarianSpeciality);
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.SuccessDataSave, (int)Refugio.Resources.AlertMessage.Type.Success);
                return RedirectToAction("Details", new { id = editRequest.Id });
            }
            catch (InvalidOperationException)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorProcessingEdit + ". " + Refugio.Resources.Languages.Global.ThereWereModifications, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorProcessingEdit + ". " + Refugio.Resources.Languages.Global.ErrorProcesingUpdate, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorProcessingEdit + ". " + Refugio.Resources.Languages.Global.TryAgainContactSupport, (int)Refugio.Resources.AlertMessage.Type.Error);
                return RedirectToAction("Details", new { id = editRequest.Id });
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
