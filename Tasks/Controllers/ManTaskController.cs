using Core.Domain.Model;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManTaskController: ControllerBase
    {
        private readonly IManTaskManager _manTaskManager;

        public ManTaskController(IManTaskManager manTaskManager)
        {
            _manTaskManager = manTaskManager;
        }

        [ProducesResponseType(typeof(ManTask), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var manTask = await _manTaskManager.GetAllManTasksAsync();
            return Ok(manTask);
        }

        [ProducesResponseType(typeof(ManTask), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManTaskById(int id)
        {
            var manTaskFinded = await _manTaskManager.GetManTaskByIdAsync(id);
            if (manTaskFinded == null) { return NotFound(); }
            return Ok(manTaskFinded);
        }

        [ProducesResponseType(typeof(ManTask), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddManTaskAsync(ManTask manTask)
        {
            var manTaskAdded = await _manTaskManager.InsertManTaskAsync(manTask);
            if (manTaskAdded == null) { return NotFound(); }
            return Ok(manTaskAdded);
        }

        [ProducesResponseType(typeof(ManTask), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdateManTaskAsync(ManTask manTask)
        {
            var manTaskFinded = await _manTaskManager.GetManTaskByIdAsync(manTask.Id);
            if (manTaskFinded == null) {return NotFound();}
            var manTaskUpdated = await _manTaskManager.UpdateManTaskAsync(manTask);
            return Ok(manTaskUpdated);
        }

        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManTaskAsync(int id)
        {
            var manTaskExcluded = await _manTaskManager.GetManTaskByIdAsync(id);
            if (manTaskExcluded == null) {return NotFound();}
            await _manTaskManager.DeleteManTaskAsync(id);
            return NoContent();

        }
    }
}
