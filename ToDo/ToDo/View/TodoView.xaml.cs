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
		public TodoView(string name, TodoTask recoverTask  = null)
		{
			InitializeComponent();
			todo_name = name;
			if (recoverTask != null)
				todo_list = recoverTask;
			TaskView.ItemsSource = todo_list.tasks;
		}

		void JsonSave()
		{
			string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), todo_name + ".json");
			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = JsonSerializer.Serialize(todo_list, options);
			File.WriteAllText(fileName, jsonString);
		}

		async void CreateTask(object sender, EventArgs e)
		{
			string result = await DisplayPromptAsync("New Task", "Task Name");
			
			if (result != null)
			{
				todo_list.tasks.Add(new TaskModel { item_name = result, item_status = false});
				JsonSave();
			}
		}

		async void DeleteFile(object sender, EventArgs e)
		{
			bool answer = await DisplayAlert("Delete?", "Are you sure you want to delete the file?", "Yes", "No");
			if (answer == true)
            {
				File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), todo_name + ".json"));
				await Navigation.PopAsync();
			}
		}


		public void DeleteTask(Object Sender, EventArgs args)
		{
			TaskModel recoveredTask = (TaskModel)((ImageButton)Sender).BindingContext;
			todo_list.tasks.Remove(recoveredTask);
			JsonSave();
		}

		void OnChange(object sender, EventArgs e)
        {
			JsonSave();
		}
	}
}