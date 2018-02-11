using System;
using TestToDo.Models;
using TestToDo.ViewModels;
using Xamarin.Forms;

namespace TestToDo.Views
{
    public partial class TodoItemsView : ContentPage
	{
		public TodoItemsView()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as TodoListItemsViewModel).LoadItems();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
           
            await Navigation.PushAsync(new TodoItemView() {
                BindingContext = new TodoItemViewModel(TodoApp.Service, (e.SelectedItem as TodoItem))
            });
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemView()
            {
                BindingContext = new TodoItemViewModel(TodoApp.Service, new TodoItem() { Created = DateTime.Today, Completed = false})
            });
        }
    }
}
