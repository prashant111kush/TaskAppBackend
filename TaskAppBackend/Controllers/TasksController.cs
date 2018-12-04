using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAppBackend.Models;
using TaskAppBackend.Services;

namespace TaskAppBackend.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly TaskSevice _taskSevice;
        public TasksController(TaskSevice taskService)
        {
            _taskSevice = taskService;
        }

        // GET api/tasks
        [HttpGet]
        public IActionResult Get()
        {
            var taskList = _taskSevice.GetAllTasks();
            return Ok(taskList);
        }

        // GET api/tasks/id
        [HttpGet("{id}", Name = "GetTask")]
        public IActionResult Get(Guid id)
        {
            var task = _taskSevice.GetTask(id);
            if (task == null)
            {
                return NotFound($"task with id: {id} not found");
            }
            return Ok(task);
        }

        // POST api/tasks
        [HttpPost]
        public IActionResult Post([FromBody]TaskCreateModel task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            var createdTask = _taskSevice.CreateTask(task.TaskName, task.TaskDescription, task.TaskDateTime,
                task.TaskPriority);

            return CreatedAtRoute("GetTask", new { id = createdTask.TaskId }, createdTask);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
