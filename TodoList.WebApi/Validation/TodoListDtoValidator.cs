using DataAccessLibrary.Models;
using FluentValidation;

namespace TodoList.WebApi.Validation;

public class TodoListDtoValidator : AbstractValidator<ToDoListModel>
{
    public TodoListDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(x => x.ItemToDo)
            .MinimumLength(1)
            .NotEmpty();
    }
}