﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Areas.Admin.Controllers
{
    public class SpecialityController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Models.Speciality.List model = new Models.Speciality.List();
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }

        public ActionResult SpecialityList(Refugio.Areas.Admin.Models.Speciality.List model)
        {
            try
            {
                model.Pager.TotalPages = Business.VeterinarianSpeciality.GetTotalPages(model.Pager.PageSize, model.Filters.Keyword);
                model.Pager.CurrentPage = (model.Pager.TotalPages < model.Pager.CurrentPage) ? 1 : model.Pager.CurrentPage;
                model.Specialities = Business.VeterinarianSpeciality.GetVeterinarianSpecialitiesFilteredAndPaged(model.Pager.CurrentPage, model.Pager.PageSize, model.Filters.Keyword);
                return PartialView("~/Areas/Admin/Views/Speciality/Partials/_List.cshtml", model);
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

        // GET: Admin/Specialities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Specialities/Edit/5
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
