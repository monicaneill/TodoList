using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data;

public class ToDoListData(ISqlDataAccess db) : IToDoListData
{
    public Task<IEnumerable<ToDoListModel>> GetToDoListItems() =>
        db.LoadData<ToDoListModel, dynamic>("dbo.spToDo_GetAll", new { });

    public async Task<ToDoListModel?> GetToDoListItem(int id)
    {
        var results = await db.LoadData<ToDoListModel, dynamic>(
            "dbo.spToDo_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertToDoItem(ToDoListModel item) =>
        db.SaveData("dbo.spToDo_Insert", new { item.ItemToDo, item.Completed });

    public Task UpdateToDoItem(ToDoListModel item) =>
        db.SaveData("dbo.spToDo_Update", item);

    public Task DeleteToDoItem(int id) =>
        db.SaveData("dbo.spToDo_Delete", new { Id = id });
}