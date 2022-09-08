using System;
using AutoMapper;
using Running.Application.Dto;
using Running.Domain.Entities;

namespace Running.Application.Mapping;

public class EntitiesMappingProfile : Profile
{
    public EntitiesMappingProfile()
    {
        CreateMap<Training, TrainingDto>();
        CreateMap<TrainingCreateDto, Training>();
        CreateMap<TrainingDto, Training>();
        CreateMap<TrainingUpdateDto, Training>();
        CreateMap<Run, RunDto>()
            .ForMember(m => m.TypeOfRunName, c => c.MapFrom(c => c.TypeOfRun.Name))
            .ForMember(m => m.TypeOfRunDescription, c => c.MapFrom(c => c.TypeOfRun.Description));
        CreateMap<RunDto, Run>();
        CreateMap<RunCreateDto, Run>();
        CreateMap<RunUpdateDto, Run>();
        CreateMap<TypeOfRun, TypeOfRunDto>();
    }
}

