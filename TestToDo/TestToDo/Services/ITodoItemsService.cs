using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestToDo.Models;

namespace TestToDo.Services
{
    public interface ITodoItemsService
    {
        Task<ObservableCollection<TodoItem>> GetItemsAsync();
        Task<TodoItem> GetItemAsync(int id);
        Task<int> SaveItemAsync(TodoItem item);
        Task<int> DeleteItemAsync(TodoItem item);
    }
}
