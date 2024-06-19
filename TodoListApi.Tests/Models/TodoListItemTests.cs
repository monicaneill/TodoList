using TodoListModel = TodoList.WebApi.Models.TodoList;

namespace TodoListApi.Tests.Models;

public class TodoListItemTests
{
    private TodoListModel CreateTodoList(int id, string itemToDo, bool isCompleted)
    {
        return new TodoListModel
        {
            Id = id,
            ItemToDo = itemToDo,
            IsCompleted = isCompleted
        };
    }

    [Fact]
    public void ItemToDo_CanBeAltered()
    {
        //Arrange
        var todoItem = CreateTodoList(1, "Go for run", false);

        //Act
        todoItem.ItemToDo = "Wipe counters";

        //Assert
        Assert.Equal("Wipe counters", todoItem.ItemToDo);
    }

    [Fact]
    public void ItemToDo_CannotBeEmpty()
    {
        var todoItem = CreateTodoList(1, "", false);

        Assert.Fail("ItemToDo cannot be null or empty");
    }

    [Fact]
    public void IsCompleted_CanBeChanged()
    {
        //Arrange
        var todoItem = CreateTodoList(1, "Wipe counters", false);

        //Act
        todoItem.IsCompleted = true;

        //Assert
        Assert.True(todoItem.IsCompleted);
    }

    [Fact]
    public void Id_CannotBeLessThan1()
    {
        var todoItem = CreateTodoList(0, "test item", false);

        Assert.Throws<ArgumentException>(() => todoItem);

        //Lambda in combination with throws represents the code you expect to throw an exception. 
    }
}