using Plugin.InputKit.Shared.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoView : ContentPage
	{
		public ObservableCollection<TodoTask> tasks = new ObservableCollection<TodoTask>();
		public TodoView()
		{
			InitializeComponent();
			TaskView.ItemsSource = tasks;
		}

		async void Create_task(object sender, EventArgs e)
		{
			string result = await DisplayPromptAsync("New Task", "Task Name");
			if (result != null)
			{
				tasks.Add(new TodoTask(result));
			}
		}
	}
}