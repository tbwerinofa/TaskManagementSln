using AutoMapper;
using TaskManagament.Domain;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntitys;

namespace TaskManagement.Application.MappingProfiles;

public class TaskStatusEntityProfiles:Profile
{
    public TaskStatusEntityProfiles()
    {
        CreateMap<TaskStatusEntityDto, TaskStatusEntity>().ReverseMap();
    }
}

