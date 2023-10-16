using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Models;
using Task_1.Repositories.IRepositories;

namespace Task_1.Repositories
{
    public class ExperimentRepository : IExperimentRepository
    {
        private AppDbContext _appDbContext { get; }

        public ExperimentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Device?> FindDeviceAsync(string deviceToken)
        {
            return await _appDbContext.Devices
                .Include(e => e.Results)
                    .ThenInclude(e => e.Experiment)
                .Include(e => e.Results)
                    .ThenInclude(e => e.ResultValue)
                .FirstOrDefaultAsync(e => e.Name == deviceToken);
        }

        public async Task<Experiment?> FindExperimentAsync(string experimentName)
        {
            return await _appDbContext.Experiments
                .Include(e => e.Options)
                .FirstOrDefaultAsync(e => e.Name == experimentName);
        }

        public async Task<Device> CreateDeviceAsync(string deviceToken)
        {
            var newDevice = new Device() { 
                Name = deviceToken,
            };

            await _appDbContext.Devices.AddAsync(newDevice);
            await _appDbContext.SaveChangesAsync();

            newDevice.Results = new List<Result>();

            return newDevice;
        }

        public async Task<Result> CreateResultInDevice(Device device, Experiment experiment, ExperimentOption experimentOption)
        {
            var result = new Result()
            {
                Experiment = experiment,
                ResultValue = experimentOption
            };

            device.Results.Add(result);
            await _appDbContext.SaveChangesAsync();

            return result;
        }
    }
}
