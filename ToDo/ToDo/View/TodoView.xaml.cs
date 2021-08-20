using Plugin.InputKit.Shared.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoView : ContentPage
	{
		public TodoView()
		{
			InitializeComponent();

		}

		async void Create_task(object sender, EventArgs e)
		{
		}
	}
}