using System.Runtime.CompilerServices;
using FluentAssertions;
using DataAccessLibrary.Models;

namespace TodoListApi.Tests.Models;

public class TodoListItemTests
{

    [Fact]
    public void ItemToDo_CanBeAltered()
    {
        //Arrange
        var todoObject = TodoListDataBuilder.CreateTodoList(1, "Go for run", false);

        //Act
        todoObject.ItemToDo = "Wipe counters";

        //Assert
        Assert.Equal("Wipe counters", todoObject.ItemToDo);
    }

    [Fact]
    public void Completed_CanBeChanged()
    {
        //Arrange
        var todoObject = TodoListDataBuilder.CreateTodoList(1, "Wipe counters", false);

        //Act
        todoObject.Completed = true;

        //Assert
        Assert.True(todoObject.Completed);
    }

    [Theory]
    [InlineData(nameof(ToDoListModel.Id))]
    [InlineData(nameof(ToDoListModel.ItemToDo))]
    [InlineData(nameof(ToDoListModel.Completed))]
    public void TodoListModel_ShouldHaveRequiredMemberAttributeSetOnAllProperties(string propertyName)
    {
        var requiredProperty = typeof(ToDoListModel).GetProperty(propertyName);

        requiredProperty.Should().BeDecoratedWith<RequiredMemberAttribute>();
    }
}