using Task_1.Models;

namespace Task_1.Repositories.IRepositories
{
    public interface IStatisticsRepository
    {
        public Task<List<Experiment>> GetExperiments();
        public Task<int> CountAmountOfDevicesForExperiment(Experiment experiment);
        public Task<int> CountAmountOfDevicesForOption(ExperimentOption experimentOption);
    }
}
