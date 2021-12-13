using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDo.Model
{
	public class TodoTask
	{
		public ObservableCollection<TaskModel> tasks { get; set; }
		public TodoTask()
        {
			tasks = new ObservableCollection<TaskModel>();
        }
	}
}
