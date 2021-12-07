using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
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
			string[] filePaths = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.json");
			RecoverFileName(filePaths);
			TodoList.ItemsSource = fileNames;
		}

		void RecoverFileName(string[] filePaths)
        {
			foreach (string filePath in filePaths)
            {
				string[] split_path = filePath.Split('/');
				string test = split_path.Last();
				fileNames.Add(new NameList { item_name = split_path.Last() });
			}
        } 

		async void Create_Todo(object sender, EventArgs e)
		{
			string result = await DisplayPromptAsync("New Todo", "Todo Name") + ".json";
			await Navigation.PushAsync(new TodoView(result));
		}
	}
}
