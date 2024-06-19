using System.Runtime.CompilerServices;
using FluentAssertions;
using TodoList.WebApi.Dtos;

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
    public void IsCompleted_CanBeChanged()
    {
        //Arrange
        var todoObject = TodoListDataBuilder.CreateTodoList(1, "Wipe counters", false);

        //Act
        todoObject.IsCompleted = true;

        //Assert
        Assert.True(todoObject.IsCompleted);
    }

    [Theory]
    [InlineData(nameof(TodoListDto.Id))]
    [InlineData(nameof(TodoListDto.ItemToDo))]
    [InlineData(nameof(TodoListDto.IsCompleted))]
    public void TodoListModel_ShouldHaveRequiredMemberAttributeSetOnAllProperties(string propertyName)
    {
        var requiredProperty = typeof(TodoListDto).GetProperty(propertyName);

        requiredProperty.Should().BeDecoratedWith<RequiredMemberAttribute>();
    }
}