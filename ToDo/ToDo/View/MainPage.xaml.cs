using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo.Model;
using ToDo.View;
using Xamarin.Forms;

namespace ToDo
{
	public partial class MainPage : ContentPage
	{
		public ObservableCollection<NameList> fileNames = new ObservableCollection<NameList>();
		public MainPage()
		{
			InitializeComponent();
			RecoverFileName();
			TodoList.ItemsSource = fileNames;
		}

		protected override void OnAppearing()
		{
            RecoverFileName();
            TodoList.ItemsSource = fileNames;
        }

        void RecoverFileName()
        {
			string[] filePaths = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.json");
			fileNames.Clear();
			foreach (string filePath in filePaths)
            {
				string[] splitPath = filePath.Split('/');
				fileNames.Add(new NameList { item_name = splitPath.Last().Split('.')[0]});
			}
        } 

		async void CreateTodo(object sender, EventArgs e)
		{
			string result = await DisplayPromptAsync("New Todo", "Todo Name");
			if (result != null)
			{
				await Navigation.PushAsync(new TodoView(result));
				RecoverFileName();
			}
		}

		async void ButtonClicked(object sender, EventArgs e)
        {
			Button button = (Button)sender;
			string fileName = button.Text + ".json";
			string jsonString = File.ReadAllText(Path.Combine(Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName)));
			TodoTask todoConfig = JsonSerializer.Deserialize<TodoTask>(jsonString);
			await Navigation.PushAsync(new TodoView(button.Text, todoConfig));
		}

	}
}
