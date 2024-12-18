using DataAccessLibrary.Models;

namespace TodoListApi.Tests;

public class TodoListDataBuilder
{
    public static ToDoListModel CreateTodoList(int id, string itemToDo, bool completed)
    {
        return new ToDoListModel
        {
            Id = id,
            ItemToDo = itemToDo,
            Completed = completed
        };
    }
}