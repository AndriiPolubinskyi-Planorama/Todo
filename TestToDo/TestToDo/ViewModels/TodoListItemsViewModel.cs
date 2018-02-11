using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestToDo.Models;
using TestToDo.Services;
using Xamarin.Forms;

namespace TestToDo.ViewModels
{
    class TodoListItemsViewModel: BaseViewModel
    {
        private readonly ITodoItemsService _service;
        private ObservableCollection<TodoItem> _items;
        public ObservableCollection<TodoItem> Items
        {
           get { return _items; }
           set
           {
                _items = value;
                OnPropertyChanged("Items");
           }
        }
       
        public ICommand SortByCommand { get; private set; }

        public void SortByColumn(string columnName)
        {
            Items = new ObservableCollection<TodoItem>(
                Items.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList());
        }

        public async Task LoadItems()
        {
            Items = await _service.GetItemsAsync();
        }
        public TodoListItemsViewModel(ITodoItemsService service)
        {
            _service = service;
            
            SortByCommand = new Command<string>(SortByColumn);
        }
    }
}
