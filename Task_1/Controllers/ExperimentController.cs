using Microsoft.AspNetCore.Mvc;
using Task_1.Data;
using Task_1.Models;
using Task_1.Models.DTOs;
using Task_1.Services.IServices;

namespace Task_1.Controllers
{
    [Route("api/experiment/")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        //Experiments
        private const string _buttonColor = "button_color";
        private const string _price = "price";

        private IExperimentService _experimentService { get; }
        public AppDbContext AppDbContext { get; }

        public ExperimentController(IExperimentService experimentService, AppDbContext appDbContext)
        {
            _experimentService = experimentService;
            AppDbContext = appDbContext;
        }

        [HttpGet(_buttonColor)]
        public async Task<IActionResult> ButtonColorAsync(string deviceToken)
        {
            var response = new ExperimentControllerDTO();

            response.Key = _buttonColor;
            response.Value = await _experimentService.TryExperimentAsync(deviceToken, _buttonColor);

            return Ok(response);
        }

        [HttpGet(_price)]
        public async Task<IActionResult> PriceAsync(string deviceToken)
        {
            var response = new ExperimentControllerDTO();

            response.Key = _price;
            response.Value = await _experimentService.TryExperimentAsync(deviceToken, _price);

            return Ok(response);
        }
    }
}
