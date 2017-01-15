using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTL.BLL.Services
{
    public class FlowServices : IServices<FlowDTO>
    {
        private string _nameTable = "\"Потік\"!";

        private IUoW Database { get; set; }

        public FlowServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(FlowDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                var groups = Database.Groups.GetAll();

                List<Group> groupList = new List<Group>();
                List<SubGroup> subGroupList = new List<SubGroup>();

                foreach (var group in item.GroupDTOs)
                {
                    groupList.Add(groups.FirstOrDefault(g => g.Id == group.Id));
                }

                foreach (var subGroup in item.SubGroupDTOs)
                {
                    subGroupList.Add(new SubGroup { Name = subGroup.Name, CountStudent = subGroup.CountStudent });
                }

                Flow flow = new Flow
                {
                    Name = item.Name,
                    AllCountBudget = item.AllCountBudget,
                    AllCountContract = item.AllCountContract,
                    CountSubGroupBudget = item.CountSubGroupBudget,
                    CountSubGroupContract = item.CountSubGroupContract,
                    EducationForm = item.EducationForm,
                    EducationType = item.EducationType,
                    Group = groupList,
                    SubGroup = subGroupList
                };

                Database.Flows.Create(flow);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка створення нового запису в таблиці " + _nameTable, "");
            }
        }

        public void Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису з таблиці" + _nameTable, "");
                }

                Database.Flows.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public FlowDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var flow = Database.Flows.Get(id.Value);

                if (flow == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<GroupDTO> groupDTOs = new List<GroupDTO>();

                foreach (var item in flow.Group)
                {
                    groupDTOs.Add(new GroupDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        StudentsCountBudget = item.StudentsCountBudget,
                        StudentsCountContract = item.StudentsCountContract,
                        EducationForm = item.EducationForm,
                        EducationType = item.EducationType,
                        Course = item.Course,
                        QualificationLevelId = item.QualificationLevel.Id,
                        QualificationLevelName = item.QualificationLevel.Name,
                        CathedraId = item.Cathedra.Id,
                        CathedraName = item.Cathedra.Name
                    });
                }

                List<SubGroupDTO> subGroupDTOs = new List<SubGroupDTO>();

                foreach (var item in flow.SubGroup)
                {
                    subGroupDTOs.Add(new SubGroupDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CountStudent = item.CountStudent
                    });
                }

                FlowDTO flowDTO = new FlowDTO();

                flowDTO.Id = flow.Id;
                flowDTO.Name = flow.Name;
                flowDTO.AllCountBudget = flow.AllCountBudget;
                flowDTO.AllCountContract = flow.AllCountContract;
                flowDTO.CountSubGroupBudget = flow.CountSubGroupBudget;
                flowDTO.CountSubGroupContract = flow.CountSubGroupContract;
                flowDTO.EducationForm = flow.EducationForm;
                flowDTO.EducationType = flow.EducationType;
                flowDTO.GroupDTOs = groupDTOs;
                flowDTO.SubGroupDTOs = subGroupDTOs;

                return flowDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<FlowDTO> ReadAll()
        {
            try
            {
                var flows = Database.Flows.GetAll();

                if (flows == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }


                List<FlowDTO> flowDTOs = new List<FlowDTO>();

                foreach (var item in flows)
                {

                    List<GroupDTO> groupDTOs = new List<GroupDTO>();

                    foreach (var group in item.Group)
                    {
                        groupDTOs.Add(new GroupDTO
                        {
                            Id = group.Id,
                            Name = group.Name,
                            StudentsCountBudget = group.StudentsCountBudget,
                            StudentsCountContract = group.StudentsCountContract,
                            EducationForm = group.EducationForm,
                            EducationType = group.EducationType,
                            Course = group.Course,
                            QualificationLevelId = group.QualificationLevel.Id,
                            QualificationLevelName = group.QualificationLevel.Name,
                            CathedraId = group.Cathedra.Id,
                            CathedraName = group.Cathedra.Name
                        });
                    }

                    List<SubGroupDTO> subGroupDTOs = new List<SubGroupDTO>();

                    foreach (var subGroup in item.SubGroup)
                    {
                        subGroupDTOs.Add(new SubGroupDTO
                        {
                            Id = subGroup.Id,
                            Name = subGroup.Name,
                            CountStudent = subGroup.CountStudent
                        });
                    }

                    flowDTOs.Add(new FlowDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        AllCountBudget = item.AllCountBudget,
                        AllCountContract = item.AllCountContract,
                        CountSubGroupBudget = item.CountSubGroupBudget,
                        CountSubGroupContract = item.CountSubGroupContract,
                        EducationForm = item.EducationForm,
                        EducationType = item.EducationType,
                        GroupDTOs = groupDTOs,
                        SubGroupDTOs = subGroupDTOs
                    });
                }

                return flowDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(FlowDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var flow = Database.Flows.Get(item.Id);

                if (flow == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                if (flow.Group.Count != item.GroupDTOs.Count)
                {
                    if (flow.Group.Count > item.GroupDTOs.Count)
                    {
                        DeleteGroup(flow, item);
                        AddGroup(flow, item);
                    }
                    else if (flow.Group.Count < item.GroupDTOs.Count)
                    {
                        AddGroup(flow, item);
                        DeleteGroup(flow, item);
                    }
                }
                else if (flow.Group.Count == item.GroupDTOs.Count)
                {
                    DeleteGroup(flow, item);
                    AddGroup(flow, item);
                }

                flow.Name = item.Name;
                flow.AllCountBudget = item.AllCountBudget;
                flow.AllCountContract = item.AllCountContract;
                flow.CountSubGroupBudget = item.CountSubGroupBudget;
                flow.CountSubGroupContract = item.CountSubGroupContract;
                flow.EducationForm = item.EducationForm;
                flow.EducationType = item.EducationType;

                Database.Flows.Update(flow);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }

        private void AddGroup(Flow flow, FlowDTO item)
        {
            foreach (var groupDTO in item.GroupDTOs)
            {
                var temp = flow.Group.FirstOrDefault(g => g.Id == groupDTO.Id);

                if (temp == null)
                {
                    var group = Database.Groups.Get(groupDTO.Id);
                    if (group != null)
                    {
                        flow.Group.Add(group);
                    }
                    else
                    {
                        throw new ValidationException("Дані про групу не знайдено!", "");
                    }
                }
            }
        }

        private void DeleteGroup(Flow flow, FlowDTO item)
        {
            List<Group> groupRemoveList = new List<Group>();

            foreach (var group in flow.Group)
            {
                var temp = item.GroupDTOs.FirstOrDefault(g => g.Id == group.Id);

                if (temp == null)
                {
                    groupRemoveList.Add(group);
                }
            }

            foreach (var group in groupRemoveList)
            {
                flow.Group.Remove(group);
            }
        }
    }
}
