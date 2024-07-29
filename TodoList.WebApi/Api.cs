namespace TodoList.WebApi;

public static class Api
{
    public static void ConfigureApi(this WebApplication app) //extension method
    {
        // all of my api endpoint mapping
        app.MapGet("/ToDo", GetToDoListItems);
        app.MapGet("/ToDo/id/{id}", GetToDoListItem);
        app.MapGet("/ToDo/completed/{completed}", FilterToDoListItem);
        app.MapPost("/ToDo", InsertToDoItem);
        app.MapPut("/ToDo", UpdateToDoItem);
        app.MapDelete("/ToDo", DeleteToDoItem);
    }

    private static async Task<IResult> GetToDoListItems(IToDoListData data)
    {
        try
        {
            return Results.Ok(await data.GetToDoListItems());
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> GetToDoListItem(int id, IToDoListData data)
    {
        try
        {
            var results = await data.GetToDoListItem(id);
            return results is null ? Results.NotFound() : Results.Ok(results);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> FilterToDoListItem(bool completed, IToDoListData data)
    {
        try
        {
            var results = await data.FilterToDoListItem(completed);
            return results is null ? Results.NotFound() : Results.Ok(results);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> InsertToDoItem(ToDoListModel toDoList, IToDoListData data)
    {
        try
        {
            await data.InsertToDoItem(toDoList);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
    private static async Task<IResult> UpdateToDoItem(ToDoListModel toDoList, IToDoListData data)
    {
        try
        {
            await data.UpdateToDoItem(toDoList);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> DeleteToDoItem(int id, IToDoListData data)
    {
        try
        {
            await data.DeleteToDoItem(id);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}