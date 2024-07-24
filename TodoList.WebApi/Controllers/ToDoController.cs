using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/ToDoController>/5
    [HttpGet("id/{id}")]
    public string GetById(int id)
    {
        return $"value {id}";
    }

    [HttpGet("completed/{completed}")]
    public string GetByCompletionStatus(bool completed)
    {
        return completed ? "completed task" : "not completed task";
    }

    // POST api/<ToDoController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ToDoController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ToDoController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}