using DataAccessLibrary.Models;

namespace TodoListApi.Tests;

public class TodoListDataBuilder
{
    public static ToDoListData CreateTodoList(int id, string itemToDo, bool Completed)
    {
        return new ToDoListData
        {
            Id = id,
            ItemToDo = itemToDo,
            Completed = Completed
        };
    }
}