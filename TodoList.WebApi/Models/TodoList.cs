namespace TodoList.WebApi.Models;

public class TodoList
{
    public required int Id { get; set; }
    public required string ItemToDo { get; set; }
    public required bool IsCompleted { get; set; }
}