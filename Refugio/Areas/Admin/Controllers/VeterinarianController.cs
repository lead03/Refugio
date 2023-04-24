using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            try
            {
                Models.Veterinarian.List model = new Models.Veterinarian.List();
                model.Filters.VeterinarianSpeciality = Business.VeterinarianSpeciality.GetSelectListForVeterinarianSpeciality();
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }

        public ActionResult VeterinarianList(Models.Veterinarian.List model)
        {
            try
            {
                model.Pager.TotalPages = Business.Veterinarian.GetTotalPages(model.Pager.PageSize, model.Filters.Keyword, model.Filters.SelectedVeterinarianSpecialityId);
                model.Pager.CurrentPage = (model.Pager.TotalPages < model.Pager.CurrentPage || model.Filters.FilterModified) ? 1 : model.Pager.CurrentPage;
                model.Filters.FilterModified = false;
                model.Veterinarians = Business.Veterinarian.GetVeterinariansFilteredAndPaged(model.Pager.CurrentPage, model.Pager.PageSize, model.Filters.Keyword, model.Filters.SelectedVeterinarianSpecialityId);
                return PartialView("~/Areas/Admin/Views/Veterinarian/Partials/_List.cshtml", model);
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
                Models.Veterinarian.Details model = new Models.Veterinarian.Details();
                if (request.Id.HasValue)
                {
                    DTO.Veterinarian veterinarian = Business.Veterinarian.GetVeterinarianById(request.Id.Value);
                    if (veterinarian == null)
                    {
                        throw new KeyNotFoundException(Refugio.Resources.Languages.Global.VeterinarianNotFoundById);
                    }
                    Business.Common.Map<DTO.Veterinarian, Models.Veterinarian.Details>(veterinarian, model);
                    model.SpecialityName = Business.Veterinarian.GetSpecialityName(veterinarian);
                    return View(model);
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
                Models.Veterinarian.Edit model = new Models.Veterinarian.Edit();
                model.VeterinarianSpecialityList = Business.VeterinarianSpeciality.GetSelectListForVeterinarianSpeciality();
                model.TimeSlotRangeList = new SelectList(Business.TimeSlotRange.GetAll(), "Id", "TimeRange");
                if (request.Id.HasValue)
                {
                    DTO.Veterinarian veterinarian = Business.Veterinarian.GetVeterinarianById(request.Id.Value);
                    if (veterinarian == null)
                    {
                        throw new KeyNotFoundException(Refugio.Resources.Languages.Global.VeterinarianNotFoundById);
                    }
                    model.GetValues(veterinarian);
                }
                return View(model);
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
        public ActionResult Edit(Models.Veterinarian.Edit model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.VeterinarianSpecialityList = Business.VeterinarianSpeciality.GetSelectListForVeterinarianSpeciality();
                    model.TimeSlotRangeList = new SelectList(Business.TimeSlotRange.GetAll(), "Id", "TimeRange");
                    return View(model);
                }
                DTO.Veterinarian veterinarian = new DTO.Veterinarian();
                if (!model.IsNewUser)
                {
                    veterinarian = Business.Veterinarian.GetVeterinarianById(model.Id);
                    Business.Common.CheckRowVersion(model.RowVersion, veterinarian.RowVersion);
                }
                else
                {
                    veterinarian.UserPassword = Refugio.Resources.Common.DefaultPassword;
                }
                model.SetValues(veterinarian);
                model.Id = Business.Veterinarian.Save(veterinarian);
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.SuccessDataSave, (int)Refugio.Resources.AlertMessage.Type.Success);
                return RedirectToAction("Details", new { id = model.Id });
            }
            catch (InvalidOperationException)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorProcessingEdit + ". "+ Refugio.Resources.Languages.Global.ThereWereModifications, (int)Refugio.Resources.AlertMessage.Type.Error);
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
                return RedirectToAction("Details", new { id = model.Id });
            }
        }

        public ActionResult Delete (Refugio.Models.Shared.RequestById request)
        {
            try
            {
                if (request.Id.HasValue)
                {
                    DTO.Veterinarian veterinarian = Business.Veterinarian.GetVeterinarianById(request.Id.Value);
                    if (veterinarian == null)
                    {
                        throw new KeyNotFoundException(Refugio.Resources.Languages.Global.VeterinarianNotFoundById);
                    }
                    Business.Veterinarian.Delete(veterinarian);
                    Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.SuccessDataDelete, (int)Refugio.Resources.AlertMessage.Type.Success);
                }
                else
                {
                    throw new KeyNotFoundException(Refugio.Resources.Languages.Global.IdNotProvided);
                }
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorDeletingRegister + ".  " + ex.Message, (int)Refugio.Resources.AlertMessage.Type.Error);
            }
            catch (DbUpdateException)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorDeletingRegister + ". " + Refugio.Resources.Languages.Global.ErrorProcesingUpdate, (int)Refugio.Resources.AlertMessage.Type.Error);
            }
            catch (Exception)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.Resources.Languages.Global.ErrorDeletingRegister + ". " + Refugio.Resources.Languages.Global.TryAgainContactSupport, (int)Refugio.Resources.AlertMessage.Type.Error);
            }
            return RedirectToAction("Index");
        }
    }
}