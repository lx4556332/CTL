using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataYearsCountController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataYearsCountController(IUoWBLL data)
        {
            dataServices = data;
        }

        // GET: Admin/InputDataYearsCount
        public ActionResult Index()
        {
            try
            {
                IEnumerable<YearsCountDTO> yearsCountDTO = dataServices.YearsCounts.ReadAll();

                List<YearsCountViewModel> yearsCountViewModel = new List<YearsCountViewModel>();

                foreach (var item in yearsCountDTO)
                {
                    yearsCountViewModel.Add(new YearsCountViewModel { Id = item.Id, Name = item.Name });
                }

                return View(yearsCountViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        // GET: Admin/CreateYearsCount
        public ActionResult CreateYearsCount()
        {
            return View();
        }

        // POST: Admin/CreateYearsCount
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateYearsCount(YearsCountViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var yearsCountDTO = new YearsCountDTO { Name = model.Name };
                    dataServices.YearsCounts.Create(yearsCountDTO);
                }

                return RedirectToAction("Index", "InputDataYearsCount");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        // GET: Admin/EditYearsCount
        public ActionResult EditYearsCount(int? id)
        {
            try
            {
                YearsCountViewModel yearsCountViewModel = new YearsCountViewModel();
                if (id != null)
                {
                    var yearsCount = dataServices.YearsCounts.Read(id);
                    if (yearsCount != null)
                    {
                        yearsCountViewModel.Id = yearsCount.Id;
                        yearsCountViewModel.Name = yearsCount.Name;
                    }
                }

                return View(yearsCountViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        // POST: Admin/EditYearsCount
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditYearsCount(YearsCountViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    YearsCountDTO yearsCountDTO = new YearsCountDTO { Id = model.Id, Name = model.Name };
                    dataServices.YearsCounts.Update(yearsCountDTO);
                }
                else
                {
                    return View(model);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataYearsCount");
        }

        // GET: Admin/DeleteYearsCount
        public ActionResult DeleteYearsCount(int? id)
        {
            try
            {
                YearsCountViewModel yearsCountViewModel = new YearsCountViewModel();
                if (id != null)
                {
                    var yearsCount = dataServices.YearsCounts.Read(id);
                    if (yearsCount != null)
                    {
                        yearsCountViewModel.Id = yearsCount.Id;
                        yearsCountViewModel.Name = yearsCount.Name;
                    }
                }

                return View(yearsCountViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        // POST: Admin/DeleteYearsCount
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteYearsCount(YearsCountViewModel model)
        {
            try
            {
                if (model != null)
                {
                    YearsCountDTO yearsCountDTO = new YearsCountDTO { Id = model.Id };
                    dataServices.YearsCounts.Delete(yearsCountDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataYearsCount");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}