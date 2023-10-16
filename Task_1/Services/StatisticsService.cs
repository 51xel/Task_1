using Task_1.Models;
using Task_1.Models.DTOs;
using Task_1.Repositories.IRepositories;
using Task_1.Services.IServices;

namespace Task_1.Services
{
    public class StatisticsService : IStatisticsService
    {
        private IStatisticsRepository _statisticsRepository { get; }

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<StatisticsControllerDTO> GetStatistics()
        {
            var result = new StatisticsControllerDTO {
                Statistics = new List<ExperimentStatistics>()
            };

            var exp = await _statisticsRepository.GetExperiments();

            foreach (var experiment in exp)
            {
                var expStat = new ExperimentStatistics {
                    Name = experiment.Name,
                    AmountOfDevices = await _statisticsRepository.CountAmountOfDevicesForExperiment(experiment),
                    OptionStatistics = new List<ExperimentOptionStatistics>()
                };

                foreach (var option in experiment.Options)
                {
                    var expStatOp = new ExperimentOptionStatistics { 
                        Name = option.Value,
                        AmountOfDevices = await _statisticsRepository.CountAmountOfDevicesForOption(option)
                    };

                    expStat.OptionStatistics.Add(expStatOp);
                }

                result.Statistics.Add(expStat);
            }

            return result;
        }
    }
}
