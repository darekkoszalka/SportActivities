using System;
using Running.Domain.Entities;

namespace Running.Domain.IRepositories;

public interface ITrainingRepository
{
    Task<IList<Training>> GetAllTrainings();
    Task<IList<Training>> GetAllUserTrainings(Guid userId);
    Task<Training> GetTrainingById(int trainingId);
    Task<int> Create(Training training);
    Task Update(Training training);
    Task Delete(Training training);
}

