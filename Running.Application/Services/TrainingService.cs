using System;
using AutoMapper;
using Running.Application.Dto;
using Running.Domain.Entities;
using Running.Domain.IRepositories;

namespace Running.Application.Services;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IMapper _mapper;


    public TrainingService(ITrainingRepository trainingRepository, IMapper mapper)
    {
        _trainingRepository = trainingRepository;
        _mapper = mapper;
    }

    public IMapper Mapper { get; }

    public async Task<int> Create(TrainingCreateDto trainingCreateDto)
    {
        var training = _mapper.Map<Training>(trainingCreateDto);
        training.CreateDate = DateTime.Now;
        var id = await _trainingRepository.Create(training);
        return id;
    }

    public async Task<List<TrainingDto>> GetAll()
    {
        var trainings = await _trainingRepository.GetAllTrainings();
        return _mapper.Map<List<TrainingDto>>(trainings);
    }

    public async Task<List<TrainingDto>> GetAllByUserId(Guid userId)
    {
        var trainings = await _trainingRepository.GetAllUserTrainings(userId);
        return _mapper.Map<List<TrainingDto>>(trainings);
    }

    public async Task Update(TrainingUpdateDto trainingUpdateDto)
    {
        var trainingExists = await _trainingRepository.GetTrainingById(trainingUpdateDto.Id);
        if(trainingExists is null)
        {
            throw new Exception("Training doesn't exists.");
        }

        var training = _mapper.Map(trainingUpdateDto, trainingExists);
        training.UpdateDate = DateTime.Now;
        await _trainingRepository.Update(training);

    }

    public async Task Delete(int trainingId)
    {
        var trainingExists = await _trainingRepository.GetTrainingById(trainingId);
        if(trainingExists is null)
        {
            throw new Exception("Training doesn't exist.");
        }
        
        await _trainingRepository.Delete(trainingExists);
    }
}

