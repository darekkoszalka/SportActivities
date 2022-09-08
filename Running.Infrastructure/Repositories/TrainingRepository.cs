using System;
using Microsoft.EntityFrameworkCore;
using Running.Domain.Entities;
using Running.Domain.IRepositories;
using Running.Infrastructure.Data;

namespace Running.Infrastructure.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly RunningDbContext _context;

        public TrainingRepository(RunningDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Training training)
        {
            await _context.Trainings.AddAsync(training);
            await _context.SaveChangesAsync();
            

            return training.Id;
        }

        public async Task Delete(Training training)
        {
            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Training>> GetAllTrainings()
        {
            var trainings = await _context.Trainings
                .Include(t => t.Runs)
                .ThenInclude(r => r.TypeOfRun)
                .OrderByDescending(t => t.TrainingDate)
                .AsNoTracking()
                .ToListAsync();
            return trainings;
        }

        public async Task<IList<Training>> GetAllUserTrainings(Guid userId)
        {
            var trainings = await _context.Trainings
                .Include(t => t.Runs)
                //whereUserId
                .ThenInclude(r => r.TypeOfRun)
                .OrderByDescending(t => t.TrainingDate)
                .AsNoTracking()
                .ToListAsync();
            return trainings;
        }

        public async Task<Training> GetTrainingById(int trainingId)
        {
            return await _context.Trainings
                .Include(t => t.Runs)
                .FirstOrDefaultAsync(t => t.Id == trainingId);
        }

        public async Task Update(Training training)
        {
            _context.Entry(training).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

