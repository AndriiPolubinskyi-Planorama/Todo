using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TestToDo.Models;

namespace TestToDo.Services
{
    public class FakeDataService : ITodoItemsService
    {
        private readonly List<TodoItem> _list = new List<TodoItem>();

        public FakeDataService()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                TodoItem ti = new TodoItem();
                ti.TodoId = i;
                ti.TodoName = "Test #" + i * r.Next();
                ti.Completed = i % 2 == 0;
                ti.Created = DateTime.Today.AddDays(i * -2);
                _list.Add(ti);
            }
        }
        public Task<int> DeleteItemAsync(TodoItem item)
        {
            _list.Remove(item);
            return Task.FromResult(0);
          
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            return await Task.FromResult(_list.Where(x => x.TodoId == id).FirstOrDefault());
        }

        public async Task<ObservableCollection<TodoItem>> GetItemsAsync()
        {
            return await Task.FromResult(new ObservableCollection<TodoItem>(_list));
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            int resultId = 0;
            if (item.TodoId == 0)
            {
                _list.Add(item);
                resultId = _list[_list.Count - 1].TodoId;
            }
            else
            {
                TodoItem sourceItem = await GetItemAsync(item.TodoId);
                sourceItem.TodoName = item.TodoName;
                sourceItem.Created = item.Created;
                sourceItem.Completed = item.Completed;
                resultId = item.TodoId;
            }
            return await Task.FromResult(resultId);
        }
    }
}
