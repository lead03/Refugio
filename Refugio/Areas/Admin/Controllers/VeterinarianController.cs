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
                if (TempData["ShowMessage"] != null)
                {
                    model.Message = new Refugio.Models.Shared.Message(TempData);
                }
                model.Pager.CurrentPage = 1;
                model.Pager.TotalPages = Business.Veterinarian.GetTotalPages(model.Pager.PageSize);
                model.Filters.VeterinarianSpeciality = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
                model.Veterinarians = Business.Veterinarian.GetVeterinariansFilteredAndPaged(model.Pager.CurrentPage, model.Pager.PageSize);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Index(Models.Veterinarian.List model)
        {
            try
            {
                model.Pager.TotalPages = Business.Veterinarian.GetTotalPages(model.Pager.PageSize, model.Filters.Keyword, model.Filters.SelectedVeterinarianSpecialityId);
                model.Pager.CurrentPage = (model.Pager.TotalPages < model.Pager.CurrentPage || model.Filters.FilterModified) ? 1 : model.Pager.CurrentPage;
                model.Filters.VeterinarianSpeciality = new SelectList(Business.VeterinarianSpeciality.GetAll(), "Id", "SpecialityName");
                model.Filters.FilterModified = false;
                model.Veterinarians = Business.Veterinarian.GetVeterinariansFilteredAndPaged(model.Pager.CurrentPage, model.Pager.PageSize, model.Filters.Keyword, model.Filters.SelectedVeterinarianSpecialityId);
            }
            catch
            {
                Business.AlertMessage.Set(TempData, true, "Error al procesar el listado. Vuelva a intentarlo. Si el error persiste contacte con soporte", (int)Business.Common.AlertMessageType.Error);
            }
            return View(model);
        }

        public ActionResult Details(Refugio.Models.Shared.RequestById request)
        {
            try
            {
                Models.Veterinarian.Details model = new Models.Veterinarian.Details();
                if (TempData["ShowMessage"] != null)
                {
                    model.Message = new Refugio.Models.Shared.Message(TempData);
                }
                if (request.Id.HasValue)
                {
                    DTO.Veterinarian veterinarian = Business.Veterinarian.GetVeterinarianById(request.Id.Value);
                    if (veterinarian == null)
                    {
                        throw new KeyNotFoundException("No se encuentra ningún veterinario con este identificador");
                    }
                    model.GetValues(veterinarian);
                    return View(model);
                }
                else
                {
                    throw new KeyNotFoundException("No se ha brindado el identificador");
                }
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al mostrar los detalles. " + ex.Message, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch
            {
                Business.AlertMessage.Set(TempData, true, "Error al mostrar los detalles. Vuelva a intentarlo. Si el error persiste contacte con soporte", (int)Business.Common.AlertMessageType.Error);
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
                        throw new KeyNotFoundException("No se encuentra ningún veterinario con este identificador");
                    }
                    model.GetValues(veterinarian);
                }
                return View(model);
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al procesar la edición. " + ex.Message, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch
            {
                Business.AlertMessage.Set(TempData, true, "Error al procesar la edición. Vuelva a intentarlo. Si el error persiste contacte con soporte", (int)Business.Common.AlertMessageType.Error);
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
                Business.AlertMessage.Set(TempData, true, "Los datos han sido guardados correctamente", (int)Business.Common.AlertMessageType.Success);
                return RedirectToAction("Details", new { id = model.Id });
            }
            catch (InvalidOperationException ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al realizar el guardado. " + ex.Message, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al realizar el guardado. " + ex.Message, (int)Business.Common.AlertMessageType.Error);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al realizar el guardado. Vuelva a intentarlo. Si el error persiste contacte con soporte" + ex.Message, (int)Business.Common.AlertMessageType.Error);
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
                        throw new KeyNotFoundException("No se encuentra ningún veterinario con este identificador");
                    }
                    Business.Veterinarian.Delete(veterinarian);
                    Business.AlertMessage.Set(TempData, true, "El registro ha sido eliminado correctamente", (int)Business.Common.AlertMessageType.Success);
                }
                else
                {
                    throw new KeyNotFoundException("No se ha brindado el identificador");
                }
            }
            catch (KeyNotFoundException ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al borrar el registro. " + ex.Message, (int)Business.Common.AlertMessageType.Error);
            }
            catch (DbUpdateException ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al borrar el registro. " + ex.Message, (int)Business.Common.AlertMessageType.Error);
            }
            catch (Exception ex)
            {
                Business.AlertMessage.Set(TempData, true, "Error al borrar el registro. Vuelva a intentarlo. Si el error persiste contacte con soporte" + ex.Message, (int)Business.Common.AlertMessageType.Error);
            }
            return RedirectToAction("Index");
        }
    }
}