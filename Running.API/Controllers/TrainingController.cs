using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Running.Application.Dto;
using Running.Application.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Running.API.Controllers
{
    [Route("api/training")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainings = await _trainingService.GetAll();
            return Ok(trainings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TrainingCreateDto trainingCreateDto)
        {
            var trainingId = await _trainingService.Create(trainingCreateDto);
            return Created("api/training/{trainingId}", trainingId);
        }

        [HttpDelete("{trainingId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int trainingId)
        {
            await _trainingService.Delete(trainingId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TrainingUpdateDto trainingUpdateDto)
        {
            await _trainingService.Update(trainingUpdateDto);
            return Ok();
        }
    }
}

