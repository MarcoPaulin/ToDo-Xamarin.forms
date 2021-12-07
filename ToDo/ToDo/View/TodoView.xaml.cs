using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

using ToDo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoView : ContentPage
	{
		public string todo_name;
		TodoTask todo_list = new TodoTask();
		public TodoView(string name)
		{
			InitializeComponent();
			todo_name = name;
			TaskView.ItemsSource = todo_list.tasks;
		}

		async void Create_task(object sender, EventArgs e)
		{
			string result = await DisplayPromptAsync("New Task", "Task Name");
			
			if (result != null)
			{
				todo_list.tasks.Add(new NameList { item_name = result });
				string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), todo_name);
				string jsonString = JsonSerializer.Serialize<TodoTask>(todo_list);
				File.WriteAllText(fileName, jsonString);
			}
		}
	}
}