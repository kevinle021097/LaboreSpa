﻿using FonSpa.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Models.Entity;

namespace FonSpa.Areas.Admin.Controllers
{
    public class ContentAdminController : Controller
    {
        private readonly IContentServices _contentServices;
        public ContentAdminController(IContentServices contentServices)
        {
            _contentServices = contentServices;
        }
        // GET: Admin/ContentAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listContent = _contentServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listContentPaged = listContent.ToPagedList(pageNumber, pageSize);
            ViewBag.Category = _contentServices.GetContentCategory();
            return View(listContentPaged);
        }

        public ActionResult Create()
        {
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                var addContent = _contentServices.AddContent(content);
                var idContent = addContent;
                if (idContent == 0) ModelState.AddModelError("", "Cannot Add Content!");
                return RedirectToAction("Index");
            }
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View(content);
        }


        public ActionResult Edit(long id)
        {
            var content = _contentServices.GetDetail(id);
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View(content);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Content content)
        {
            if(ModelState.IsValid)
            {
                var editSuccess = _contentServices.EditContent(content);
                if(editSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Edit fail !");
                }
            }
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View(content);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _contentServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}