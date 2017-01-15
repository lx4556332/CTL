using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataFlowController : Controller
    {
        private IUoWBLL dataServices;
        DropDownListData dropDownListData;

        public InputDataFlowController(IUoWBLL data)
        {
            dataServices = data;
            dropDownListData = new DropDownListData(data);
        }

        //Список потоків
        // GET: Admin/InputDataFlow
        public ActionResult Index()
        {
            try
            {
                IEnumerable<FlowDTO> flowDTO = dataServices.Flows.ReadAll();

                List<FlowViewModel> flowViewModel = new List<FlowViewModel>();

                foreach (var item in flowDTO)
                {
                    flowViewModel.Add(new FlowViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        AllCountBudget = item.AllCountBudget,
                        AllCountContract = item.AllCountContract,
                        CountSubGroupBudget = item.CountSubGroupBudget,
                        CountSubGroupContract = item.CountSubGroupContract,
                        EducationForm = item.EducationForm,
                        EducationType = item.EducationType,
                    });
                }

                return View(flowViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення потоку
        // GET: Admin/CreateFlow
        [HttpGet]
        public ActionResult CreateFlow()
        {
            return View();
        }

        //Створення потоку
        // POST: Admin/CreateAppointment
        [HttpPost]
        public ActionResult CreateFlow(FlowViewModel model)
        {
            try
            {
                var flowDTO = new FlowDTO
                {
                    Name = model.Name,
                    AllCountBudget = model.AllCountBudget,
                    AllCountContract = model.AllCountContract,
                    CountSubGroupBudget = model.CountSubGroupBudget,
                    CountSubGroupContract = model.CountSubGroupContract,
                    EducationForm = model.EducationForm,
                    EducationType = model.EducationType,
                    GroupDTOs = model.selectedGroupList,
                    SubGroupDTOs = model.subGroupList
                };

                dataServices.Flows.Create(flowDTO);

                return RedirectToAction("Index", "InputDataFlow");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        //Редагування потоку
        // GET: Admin/EditFlow
        [HttpGet]
        public ActionResult EditFlow(int? id)
        {
            return View();
        }

        //Редагування потоку
        // POST: Admin/EditFlow
        [HttpPost]
        public ActionResult EditFlow(FlowViewModel model)
        {
            try
            {
                FlowDTO flowDTO = new FlowDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    AllCountBudget = model.AllCountBudget,
                    AllCountContract = model.AllCountContract,
                    CountSubGroupBudget = model.CountSubGroupBudget,
                    CountSubGroupContract = model.CountSubGroupContract,
                    EducationForm = model.EducationForm,
                    EducationType = model.EducationType,
                    GroupDTOs = model.selectedGroupList,
                    SubGroupDTOs = model.subGroupList
                };

                dataServices.Flows.Update(flowDTO);

            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataFlow");
        }

        //Видалення потоку
        // GET: Admin/DeleteFlow
        public ActionResult DeleteFlow(int? id)
        {
            try
            {
                FlowViewModel flowViewModel = new FlowViewModel();
                if (id != null)
                {
                    var flow = dataServices.Flows.Read(id);
                    if (flow != null)
                    {
                        flowViewModel.Id = flow.Id;
                        flowViewModel.Name = flow.Name;
                        flowViewModel.AllCountBudget = flow.AllCountBudget;
                        flowViewModel.AllCountContract = flow.AllCountContract;
                        flowViewModel.CountSubGroupBudget = flow.CountSubGroupBudget;
                        flowViewModel.CountSubGroupContract = flow.CountSubGroupContract;
                        flowViewModel.EducationForm = flow.EducationForm;
                        flowViewModel.EducationType = flow.EducationType;
                    }
                }

                return View(flowViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення потоку
        // POST: Admin/DeleteAppointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFlow(FlowViewModel model)
        {
            try
            {
                if (model != null)
                {
                    FlowDTO flowDTO = new FlowDTO { Id = model.Id };
                    dataServices.Flows.Delete(flowDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataFlow");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult GetGroup()
        {
            IEnumerable<GroupDTO> groupData = dataServices.Groups.ReadAll();
            List<GroupViewModel> groupViewModel = new List<GroupViewModel>();

            foreach (var item in groupData)
            {
                groupViewModel.Add(new GroupViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    StudentsCountBudget = item.StudentsCountBudget,
                    StudentsCountContract = item.StudentsCountContract,
                    StudentsCountTotal = item.StudentsCountBudget + item.StudentsCountContract,
                    EducationType = item.EducationType,
                    EducationForm = item.EducationForm,
                    Course = item.Course,
                    QualificationLevelName = item.QualificationLevelName,
                    CathedraName = item.CathedraName,
                });
            }

            return Json(groupViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}