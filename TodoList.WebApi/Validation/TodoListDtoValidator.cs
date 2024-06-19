using FluentValidation;
using TodoList.WebApi.Dtos;

namespace TodoList.WebApi.Validation;

public class TodoListDtoValidator : AbstractValidator<TodoListDto>
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