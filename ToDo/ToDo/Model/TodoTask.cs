using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Model
{
	public class TodoTask
	{
		public string Name { get; }

		public TodoTask(string name)
		{
			Name = name;
		}
	}
}
