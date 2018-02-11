using TestToDo.Services;
using TestToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TestToDo
{
    public partial class TodoApp : Application
	{
        public static ITodoItemsService Service;
		public TodoApp ()
		{
			InitializeComponent();

            // Service = new FakeDataService();
            Service = new TodoItemsLocalDbService();
            MainPage = new NavigationPage(new Views.TodoItemsView()
            {
                BindingContext = new TodoListItemsViewModel(Service)
            });
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
