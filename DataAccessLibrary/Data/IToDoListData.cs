using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
    public interface IToDoListData
    {
        Task DeleteToDoItem(int id);
        Task<ToDoListModel?> GetToDoListItem(int id);
        Task<IEnumerable<ToDoListModel>> GetToDoListItems();
        Task InsertToDoItem(ToDoListModel item);
        Task UpdateToDoItem(ToDoListModel item);
    }
}