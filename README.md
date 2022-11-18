# How-to-bind-the-CSV-data-in-WPF-Chart
This sample demonstrates how to bind the CSV data to the WPF SfChart with the following steps.

 Step 1: Initialize a data model that represents a data point for the Chart.

**[C#]**

```
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

```

Step 2: Store the list of the data model (numbers and text) in a CSV file. Each line of the file is a data model. Each model consists of two fields, separated by commas.

**[CSV Data]**

```
Month,Appointments
Jan,360
Feb,490
Mar,250
Apr,670
May,575
Jun,430
Jul,680
Aug,345
Sep,563
Oct,420
Nov,634
Dec, 277
```

Step 3: You can convert CSV data to the list of models by using the below code snippet.

**[ViewModel]**

```
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
		//First row containing column names
		lines.RemoveAt(0);

		return lines.Select(line =>
		{
			string[] data = line.Split(',');
			return new Model(Convert.ToString(data[0]), Convert.ToDouble(data[1]));
		});
	}
}

```
Step 4: Bind the converted data collection to the SfChart.

**[XAML]**

  ```
<chart:ColumnSeries ItemsSource="{Binding Data}"
                    XBindingPath="Month"
                    YBindingPath="Appointments"/>
  ```

## Output:

![Binding CSV data to the WPF Charts](https://user-images.githubusercontent.com/61832185/202696426-136c3817-3db7-4e80-8196-ebdea3d4d84a.png)

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
