using NTierProject.Model.Option;
using NTierProject.Service.Option;
using NTierProject.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            _categoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult List()
        {
            List<Category> model = _categoryService.GetActive();
            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            Category cat = _categoryService.GetByID(id);
            CategoryDTO model = new CategoryDTO();
            model.ID = cat.ID;
            model.Name = cat.Name;
            model.Description = cat.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoryDTO data)
        {
            Category cat = _categoryService.GetByID(data.ID);
            cat.Name = data.Name;
            cat.Description = data.Description;
            _categoryService.Update(cat);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.Remove(id);
            return Redirect("/Admin/Category/List");
        }

    }
}