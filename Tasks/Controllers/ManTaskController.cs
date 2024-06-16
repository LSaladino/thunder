using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using Shared.Modelviews.ManTask;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManTaskController : ControllerBase
    {
        private readonly IManTaskManager _manTaskManager;

        public ManTaskController(IManTaskManager manTaskManager)
        {
            _manTaskManager = manTaskManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ManTaskView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var manTask = await _manTaskManager.GetAllManTasksAsync();

            if (manTask.Any())
            {
                return Ok(manTask);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ManTaskView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var manTaskFinded = await _manTaskManager.GetManTaskByIdAsync(id);

            if (manTaskFinded.Id == 0)
            {
                return NotFound();
            }
            return Ok(manTaskFinded);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ManTaskView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NewManTask newManTask)
        {
            var manTaskAdded = await _manTaskManager.InsertManTaskAsync(newManTask);
            if (manTaskAdded == null) { return NotFound(); }
            return CreatedAtAction(nameof(Get), new { id = manTaskAdded.Id }, manTaskAdded);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ManTaskView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateManTask updateManTask)
        {
            var manTaskUpdated = await _manTaskManager.UpdateManTaskAsync(updateManTask);
            if (manTaskUpdated == null)
            {
                return NotFound();
            }
            return Ok(manTaskUpdated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var manTaskExcluded = await _manTaskManager.DeleteManTaskAsync(id);
            if (manTaskExcluded == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
