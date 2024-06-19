namespace TodoList.WebApi.Dtos;

public class TodoListDto
{
    public required int Id { get; set; }
    public required string ItemToDo { get; set; }
    public required bool IsCompleted { get; set; } = false;
}