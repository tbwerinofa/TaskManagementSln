using AutoMapper;
using TaskManagament.Domain;
using TaskManagement.Application.Features.TaskEntity.Commands.CreateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Commands.UpdateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;

namespace TaskManagement.Application.MappingProfiles;

public class TaskEntityProfiles:Profile
{
    public TaskEntityProfiles()
    {
        CreateMap<TaskEntityDto, TaskEntity>().ReverseMap();
        CreateMap<CreateTaskEntityCommand, TaskEntity>();
        CreateMap<UpdateTaskEntityCommand, TaskEntity>();
    }
}

