using Task_1.Models;

namespace Task_1.Repositories.IRepositories
{
    public interface IExperimentRepository
    {
        public Task<Device?> FindDeviceAsync(string deviceToken);
        public Task<Experiment?> FindExperimentAsync(string experimentName);
        public Task<Device> CreateDeviceAsync(string deviceToken);
        public Task<Result> CreateResultInDevice(Device device, Experiment experiment, ExperimentOption experimentOption);

    }
}
