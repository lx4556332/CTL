using CTL.BLL.DTO;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CTL.WEB.Areas.Admin.Controllers.WebAPI
{
    [Authorize(Roles = "admin")]
    public class SubGroupController : ApiController
    {
        private IUoWBLL dataServices;

        public SubGroupController(IUoWBLL data)
        {
            dataServices = data;
        }

        // GET: api/SubGroup
        public IEnumerable<SubGroupViewModel> Get()
        {
            IEnumerable<SubGroupDTO> subGroupDTO = dataServices.SubGroups.ReadAll();
            
            List<SubGroupViewModel> subGroupViewModel = new List<SubGroupViewModel>();
            foreach (var item in subGroupDTO)
            {
                subGroupViewModel.Add(new SubGroupViewModel { Id = item.Id, Name = item.Name, CountStudent = item.CountStudent });
            }
            return subGroupViewModel;

        }

        // POST: api/SubGroup
        public void Post([FromBody]SubGroupViewModel model)
        {
            if (model != null)
            {
                SubGroupDTO subGroupDTO = new SubGroupDTO
                {
                    Name = model.Name,
                    CountStudent = model.CountStudent,
                    FlowId = model.FlowId
                };

                dataServices.SubGroups.Create(subGroupDTO);
            }
        }

        // PUT: api/SubGroup/5
        public void Put(int id, [FromBody]SubGroupViewModel model)
        {
            if (model != null)
            {
                SubGroupDTO subGroupDTO = new SubGroupDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    CountStudent = model.CountStudent
                };

                dataServices.SubGroups.Update(subGroupDTO);
            }
        }

        // DELETE: api/SubGroup/5
        public void Delete(int id)
        {
            dataServices.SubGroups.Delete(id);
        }
    }
}
