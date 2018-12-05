using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAppBackend.Converters;
using TaskAppBackend.Models;
using TaskCore;
using TaskCore.Services;

namespace TaskAppBackend.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskSevice;
        public TasksController(ITaskService taskService)
        {
            _taskSevice = taskService;
        }

        // GET api/tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var taskList = _taskSevice.GetAllTasks();
            var taskModelList = taskList.Select(ConvertCoreTaskToTaskModel.ConvertToTaskModel);
            return Ok(taskModelList);
        }

        // GET api/tasks/id
        [HttpGet("{id}", Name = "GetTask")]
        public IActionResult GetTask(Guid id)
        {
            var task = _taskSevice.GetTask(id);
            var taskModel = ConvertCoreTaskToTaskModel.ConvertToTaskModel(task);
            if (taskModel == null)
            {
                return NotFound($"task with id: {id} not found");
            }
            return Ok(taskModel);
        }

        // POST api/tasks
        [HttpPost]
        public IActionResult CreateTask([FromBody]TaskCreateModel task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTask = _taskSevice.CreateTask(task.TaskName, task.TaskDescription, task.TaskDateTime,
                task.TaskPriority);

            var createdTaskModel = ConvertCoreTaskToTaskModel.ConvertToTaskModel(createdTask);

            return CreatedAtRoute("GetTask", new { id = createdTaskModel.TaskId }, createdTaskModel);
        }

        // PUT api/tasks/id
        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody]TaskUpdateModel task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTask = _taskSevice.GetTask(id);

            if (existingTask == null)
            {
                return NotFound($"The task with id : {id} was not found.");
            }

            _taskSevice.UpdateTask(id, task.TaskName, task.TaskDescription, task.TaskDateTime,task.TaskPriority);

            return NoContent();
        }

        // DELETE api/tasks/id
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var existingTask = _taskSevice.GetTask(id);

            if (existingTask == null)
            {
                return NotFound($"The task with id : {id} was not found.");
            }

            _taskSevice.DeleteTask(id);

            return NoContent();
        }
    }
}
