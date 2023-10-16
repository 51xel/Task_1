using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Models;
using Task_1.Repositories.IRepositories;

namespace Task_1.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private AppDbContext _appDbContext { get; }

        public StatisticsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CountAmountOfDevicesForExperiment(Experiment experiment)
        {
            return await _appDbContext
                .Results
                    .Include(e => e.Experiment)
                    .Where(e => e.Experiment.Id == experiment.Id)
                    .CountAsync();
        }

        public async Task<int> CountAmountOfDevicesForOption(ExperimentOption experimentOption)
        {
            return await _appDbContext
                .Results
                    .Include(e => e.ResultValue)
                    .Where(e => e.ResultValue.Id == experimentOption.Id)
                    .CountAsync();
        }

        public async Task<List<Experiment>> GetExperiments()
        {
            return await _appDbContext.Experiments.Include(e => e.Options).ToListAsync();
        }
    }
}
