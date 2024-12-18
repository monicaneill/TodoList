using FluentValidation;

namespace TodoList.WebApi.Validation;

public class TodoListDtoValidator : AbstractValidator<ToDoListModel>
{
    public TodoListDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ItemToDo)
            .MinimumLength(1)
            .NotEmpty();
    }
}