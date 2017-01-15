using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataRankController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataRankController(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список звань
        // GET: Admin/InputDataRank
        public ActionResult Index()
        {
            try
            {
                IEnumerable<RankDTO> rankDTO = dataServices.Ranks.ReadAll();

                List<RankViewModel> rankViewModel = new List<RankViewModel>();

                foreach (var item in rankDTO)
                {
                    rankViewModel.Add(new RankViewModel { Id = item.Id, Name = item.Name, FullName = item.FullName });
                }

                return View(rankViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення звання
        // GET: Admin/CreateRank
        public ActionResult CreateRank()
        {
            return View();
        }

        //Створення звання
        // POST: Admin/CreateRank
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRank(RankViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var rankDTO = new RankDTO { Name = model.Name, FullName = model.FullName };
                    dataServices.Ranks.Create(rankDTO);
                }

                return RedirectToAction("Index", "InputDataRank");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        //Редагування звання
        // GET: Admin/EditRank
        public ActionResult EditRank(int? id)
        {
            try
            {
                RankViewModel rankViewModel = new RankViewModel();
                if (id != null)
                {
                    var rank = dataServices.Ranks.Read(id);
                    if (rank != null)
                    {
                        rankViewModel.Id = rank.Id;
                        rankViewModel.Name = rank.Name;
                        rankViewModel.FullName = rank.FullName;
                    }
                }

                return View(rankViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування звання
        // POST: Admin/EditRank
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRank(RankViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RankDTO rankDTO = new RankDTO { Id = model.Id, Name = model.Name, FullName = model.FullName };
                    dataServices.Ranks.Update(rankDTO);
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

            return RedirectToAction("Index", "InputDataRank");
        }

        //Видалення звання
        // GET: Admin/DeleteRank
        public ActionResult DeleteRank(int? id)
        {
            try
            {
                RankViewModel rankViewModel = new RankViewModel();
                if (id != null)
                {
                    var rank = dataServices.Ranks.Read(id);
                    if (rank != null)
                    {
                        rankViewModel.Id = rank.Id;
                        rankViewModel.Name = rank.Name;
                        rankViewModel.FullName = rank.FullName;
                    }
                }

                return View(rankViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення звання
        // POST: Admin/DeleteRank
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRank(RankViewModel model)
        {
            try
            {
                if (model != null)
                {
                    RankDTO rankDTO = new RankDTO { Id = model.Id };
                    dataServices.Ranks.Delete(rankDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataRank");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}