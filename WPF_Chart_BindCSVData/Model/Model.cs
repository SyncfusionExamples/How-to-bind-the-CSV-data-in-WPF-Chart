using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Chart_BindCSVData
{
	public class Model
	{
		public string Month { get; set; }
		public double Appointments { get; set; }
		public Model(string month, double appointments)
		{
			Month= month;
			Appointments = appointments;
		}
	}
}
