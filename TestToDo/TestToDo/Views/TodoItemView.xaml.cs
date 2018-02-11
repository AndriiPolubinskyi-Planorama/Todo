
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoItemView : ContentPage
	{
		public TodoItemView ()
		{
			InitializeComponent ();
		}
	}
}