using System.Threading.Tasks;
using System.Windows.Input;
using TestToDo.Models;
using TestToDo.Services;
using Xamarin.Forms;

namespace TestToDo.ViewModels
{
    public class TodoItemViewModel: BaseViewModel
    {
        private TodoItem _item;
        private readonly ITodoItemsService _service;

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }


        public TodoItem Item
        {
            get { return _item; }
            set {
                _item = value;
                OnPropertyChanged("Item");
            }
        }

        public bool ExistingTodo
        {
            get
            {
                return _item.TodoId != 0;
            }
        }
        public TodoItemViewModel (ITodoItemsService service, TodoItem item)
        {
            _service = service;
            _item = item;

            SaveCommand = new Command(async() => await SaveItem());

            DeleteCommand = new Command(async() => await DeleteItem());

            CancelCommand = new Command(async () => await ClosePage());
        }

        private async Task SaveItem()
        {
            await _service.SaveItemAsync(_item);
            await ClosePage();
        }

        private async Task DeleteItem()
        {
            await _service.DeleteItemAsync(_item);
            await ClosePage();
        }

        private async Task ClosePage()
        {
            await TodoApp.Current.MainPage.Navigation.PopAsync();
        }
    }
}
