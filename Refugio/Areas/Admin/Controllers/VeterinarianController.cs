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
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookieCulture = Request.Cookies["Language"]?.Value;
            if (!string.IsNullOrEmpty(cookieCulture))
            {
                var cultureInfo = new System.Globalization.CultureInfo(cookieCulture);
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
            base.OnActionExecuting(filterContext);
        }
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                Models.Veterinarian.List model = new Models.Veterinarian.List();
                model.Filters.VeterinarianSpeciality = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
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
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorProcessingListing + ". " + Refugio.App_Resources.Global.TryAgainContactSupport, (int)Business.Common.AlertMessageType.Error);
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
                        throw new KeyNotFoundException(Refugio.App_Resources.Global.VeterinarianNotFoundById);
                    }
                    model.GetValues(veterinarian);
                    return View(model);
                }
                else
                {
                    throw new KeyNotFoundException(Refugio.App_Resources.Global.IdNotProvided);
                }
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorDisplayingDetails + ". " + ex.Message, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorDisplayingDetails + ". " + Refugio.App_Resources.Global.TryAgainContactSupport, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(Refugio.Models.Shared.RequestById request)
        {
            try
            {
                Models.Veterinarian.Edit model = new Models.Veterinarian.Edit();
                model.VeterinarianSpecialityList = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
                model.TimeSlotRangeList = new SelectList(Business.TimeSlotRange.GetAll(), "Id", "TimeRange");
                if (request.Id.HasValue)
                {
                    DTO.Veterinarian veterinarian = Business.Veterinarian.GetVeterinarianById(request.Id.Value);
                    if (veterinarian == null)
                    {
                        throw new KeyNotFoundException(Refugio.App_Resources.Global.VeterinarianNotFoundById);
                    }
                    model.GetValues(veterinarian);
                }
                return View(model);
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorProcessingEdit + ". " + ex.Message, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorProcessingEdit + ". " + Refugio.App_Resources.Global.TryAgainContactSupport, (int)Business.Common.AlertMessageType.Error);
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
                    model.VeterinarianSpecialityList = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
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
                    veterinarian.UserPassword = Business.Common.DefaultPassword;
                }
                model.SetValues(veterinarian);
                model.Id = Business.Veterinarian.Save(veterinarian);
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.SuccessDataSave, (int)Business.Common.AlertMessageType.Success);
                return RedirectToAction("Details", new { id = model.Id });
            }
            catch (InvalidOperationException)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorProcessingEdit + ". "+ Refugio.App_Resources.Global.ThereWereModifications, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorProcessingEdit + ". " + Refugio.App_Resources.Global.ErrorProcesingUpdate, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorProcessingEdit + ". " + Refugio.App_Resources.Global.TryAgainContactSupport, (int)Business.Common.AlertMessageType.Error);
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
                        throw new KeyNotFoundException(Refugio.App_Resources.Global.VeterinarianNotFoundById);
                    }
                    Business.Veterinarian.Delete(veterinarian);
                    Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.SuccessDataDelete, (int)Business.Common.AlertMessageType.Success);
                }
                else
                {
                    throw new KeyNotFoundException(Refugio.App_Resources.Global.IdNotProvided);
                }
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorDeletingRegister + ".  " + ex.Message, (int)Business.Common.AlertMessageType.Error);
            }
            catch (DbUpdateException)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorDeletingRegister + ". " + Refugio.App_Resources.Global.ErrorProcesingUpdate, (int)Business.Common.AlertMessageType.Error);
            }
            catch (Exception)
            {
                Business.AlertMessage.Set(TempData, true, Refugio.App_Resources.Global.ErrorDeletingRegister + ". " + Refugio.App_Resources.Global.TryAgainContactSupport, (int)Business.Common.AlertMessageType.Error);
            }
            return RedirectToAction("Index");
        }
    }
}