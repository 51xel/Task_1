using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_1.Services.IServices;

namespace Task_1.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private IStatisticsService _statisticsService { get; }

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStaistics()
        {
            return Ok(await _statisticsService.GetStatistics());
        }
    }
}
