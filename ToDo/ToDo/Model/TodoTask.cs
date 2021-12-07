using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDo.Model
{
	public class TodoTask
	{
		public ObservableCollection<NameList> tasks = new ObservableCollection<NameList>();
	}
}
