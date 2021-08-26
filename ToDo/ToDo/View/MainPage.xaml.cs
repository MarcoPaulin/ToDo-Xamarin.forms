using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.View;
using Xamarin.Forms;

namespace ToDo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void Create_Todo(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoView());
		}
	}
}
