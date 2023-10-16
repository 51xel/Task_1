using Task_1.Models.DTOs;

namespace Task_1.Services.IServices
{
    public interface IStatisticsService
    {
        public Task<StatisticsControllerDTO> GetStatistics();
    }
}
