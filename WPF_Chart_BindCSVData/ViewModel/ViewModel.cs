using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Chart_BindCSVData
{
	public class ViewModel
	{
		public List<Model> Data { get; set; }

		public ViewModel()
		{
			Data = new List<Model>(ReadCSV("..\\..\\ChartData"));
		}

		public IEnumerable<Model> ReadCSV(string fileName)
		{
			List<string> lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv")).ToList();
			//First row containin column names
			lines.RemoveAt(0);

			return lines.Select(line =>
			{
				string[] data = line.Split(',');
				return new Model(Convert.ToString(data[0]), Convert.ToDouble(data[1]));
			});
		}
	}
}
