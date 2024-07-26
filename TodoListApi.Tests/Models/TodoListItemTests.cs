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
    [InlineData(nameof(ToDoListData.Id))]
    [InlineData(nameof(ToDoListData.ItemToDo))]
    [InlineData(nameof(ToDoListData.Completed))]
    public void TodoListModel_ShouldHaveRequiredMemberAttributeSetOnAllProperties(string propertyName)
    {
        var requiredProperty = typeof(ToDoListData).GetProperty(propertyName);

        requiredProperty.Should().BeDecoratedWith<RequiredMemberAttribute>();
    }
}