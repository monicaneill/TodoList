using FluentAssertions;
using TodoList.WebApi.Validation;

namespace TodoListApi.Tests.Validation;

public class TodoListValidationTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_Id_CannotBeLessThan1(int id)
    {
        //Arrange
        var todoListDtoValidator = new TodoListDtoValidator();
        var todoObject = TodoListDataBuilder.CreateTodoList(id, "Eat", false);

        //Act
        var result = todoListDtoValidator.Validate(todoObject);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage == "'Id' must be greater than '0'.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\n")]
    [InlineData("\r")]
    [InlineData("\r\n")]
    [InlineData("       ")]
    [InlineData(null)]
    public void Validate_ItemToDo_CannotBeEmpty(string itemToDo)
    {
        var todoListDtoValidator = new TodoListDtoValidator();
        var todoObject = TodoListDataBuilder.CreateTodoList(1, itemToDo, false);

        var result = todoListDtoValidator.Validate(todoObject);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage == "'Item To Do' must not be empty.");
    }
}