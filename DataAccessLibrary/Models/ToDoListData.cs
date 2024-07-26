namespace DataAccessLibrary.Models;

public class ToDoListData
{
    public required int Id { get; set; }
    public required string ItemToDo { get; set; }
    public required bool Completed { get; set; } = false;
}