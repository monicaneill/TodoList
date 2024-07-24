using TodoList.WebApi.Dtos;

namespace TodoListApi.Tests;

public class TodoListDataBuilder
{
    public static TodoListDto CreateTodoList(int id, string itemToDo, bool Completed)
    {
        return new TodoListDto
        {
            Id = id,
            ItemToDo = itemToDo,
            Completed = Completed
        };
    }
}