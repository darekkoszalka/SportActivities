using AutoMapper;
using Running.Application.Dto;

namespace Running.Application.Services
{
    public interface ITrainingService
    {
        IMapper Mapper { get; }

        Task<int> Create(TrainingCreateDto trainingCreateDto);
        Task Delete(int trainingId);
        Task<List<TrainingDto>> GetAll();
        Task<List<TrainingDto>> GetAllByUserId(Guid userId);
        Task Update(TrainingUpdateDto trainingUpdateDto);
    }
}