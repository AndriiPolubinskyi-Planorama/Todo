using SQLite;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using TestToDo.Models;

namespace TestToDo.Services

{
    class TodoItemsLocalDbService : ITodoItemsService
    {
        private readonly SQLiteAsyncConnection _database;

        public TodoItemsLocalDbService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "todos.db");
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<TodoItem>();
        }
        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<TodoItem> GetItemAsync(int id)
        {
            return _database.Table<TodoItem>().Where(i => i.TodoId == id).FirstOrDefaultAsync();
        }

        public async Task<ObservableCollection<TodoItem>> GetItemsAsync()
        {
            var list = await _database.Table<TodoItem>().ToListAsync();
            return new ObservableCollection<TodoItem>(list);
        }

        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.TodoId != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }
    }
}
