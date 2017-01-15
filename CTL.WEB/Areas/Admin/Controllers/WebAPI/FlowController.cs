using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CTL.WEB.Areas.Admin.Controllers.WebAPI
{
    [Authorize(Roles = "admin")]
    public class FlowController : ApiController
    {
        private IUoWBLL dataServices;

        public FlowController(IUoWBLL data)
        {
            dataServices = data;
        }

        // GET: api/Flow
        public IEnumerable<FlowViewModel> Get()
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
                    selectedGroupList = item.GroupDTOs,
                    subGroupList = item.SubGroupDTOs
                });
            }
            return flowViewModel;

        }

        // GET: api/Flow/5
        public IHttpActionResult Get(int? id)
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
                        flowViewModel.selectedGroupList = flow.GroupDTOs;
                        flowViewModel.subGroupList = flow.SubGroupDTOs;
                    }
                }

                return Ok(flowViewModel);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
        }

        // POST: api/Flow
        public void Post([FromBody]FlowViewModel model)
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
    }
}
