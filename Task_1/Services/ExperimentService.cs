using Task_1.Models;
using Task_1.Repositories.IRepositories;
using Task_1.Services.IServices;

namespace Task_1.Services
{
    public class ExperimentService : IExperimentService
    {
        private IExperimentRepository _experimentRepository { get; }

        public ExperimentService(IExperimentRepository experimentRepository)
        {
            _experimentRepository = experimentRepository;
        }

        public async Task<string> TryExperimentAsync(string deviceToken, string experimentName)
        {
            var device = await _experimentRepository.FindDeviceAsync(deviceToken);

            if (device == null)
            {
                device = await _experimentRepository.CreateDeviceAsync(deviceToken);
            }

            var results = device.Results.FirstOrDefault(e => e.Experiment.Name == experimentName);

            if (results == null)
            {
                var experiment = await _experimentRepository.FindExperimentAsync(experimentName);

                if (experiment == null)
                {
                    throw new InvalidOperationException("Non-existent experiment.");
                }

                var option = ChooseOption(experiment);
                var result = await _experimentRepository.CreateResultInDevice(device, experiment, option);

                return result.ResultValue.Value;
            }

            return results.ResultValue.Value;
        }

        private ExperimentOption ChooseOption(Experiment experiment)
        {
            Random random = new Random();

            double randomValue = random.NextDouble() * 100;

            foreach (var option in experiment.Options)
            {
                randomValue -= option.Probability;
                if (randomValue <= 0)
                {
                    return option;
                }
            }

            throw new InvalidOperationException("Invalid probability distribution in options.");
        }
    }
}
