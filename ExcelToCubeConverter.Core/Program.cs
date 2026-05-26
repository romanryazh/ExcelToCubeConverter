using System.Text;
using System.Text.RegularExpressions;
using ExcelToCubeConverter.Core;
using OfficeOpenXml;

const string excelPath = @"D:\DM_QES_ROLL_UP_PARAM_HRM2.xlsx";
const string outputPath = @"D:\DM_QES_ROLL_UP_PARAM_HRM2.yaml";

if (!File.Exists(excelPath))
{
	Console.WriteLine($"Excel файл {excelPath} не найден");
	return 1;
}

try
{
	Console.WriteLine("Начало конвертации...");
	Convert(excelPath, outputPath);

	Console.WriteLine("Конвертация завершена");

	Console.WriteLine($"Файл сохранён: {outputPath}");
	return 0;
}
catch (Exception exception)
{
	Console.WriteLine($"Ошибка: {exception.Message}");
	return 1;
}

void Convert(string excelFilePath, string outPath)
{
	ExcelPackage.License.SetNonCommercialPersonal("Mee");

	using var package = new ExcelPackage(new FileInfo(excelFilePath));

	var worksheet = package.Workbook.Worksheets[0];

	var fields = ParseExcel(worksheet);

	var yaml = GenerateYaml(fields);

	File.WriteAllText(outPath, yaml, Encoding.UTF8);
}

List<FieldInfo> ParseExcel(ExcelWorksheet worksheet)
{
	var fields = new List<FieldInfo>();

	// Console.WriteLine(worksheet.Cells[2, 1].Text.Trim());

	for (var row = 3; row <= worksheet.Dimension.Rows; row++)
	{
		var cubeName = worksheet.Cells[row, 1]
								.Text.Trim();
		cubeName = CleanName(cubeName);

		if (string.IsNullOrEmpty(cubeName))
		{
			continue;
		}

		var field = new FieldInfo()
		{
			CubeName = cubeName,
			FieldName = worksheet.Cells[row, 2]
								 .Text.Trim(),
			SqlColumn = cubeName,
			DataType = worksheet.Cells[row, 3]
								.Text.Trim(),
			IsMetric = worksheet.Cells[row, 4]
								.Text.Trim() ==
					   "Metric",
			Aggregation = worksheet.Cells[row, 5]
								   .Text.Trim()
								   .ToUpper(),
		};

		if (field.DataType.StartsWith("number"))
		{
			field.DataType = "number";
		}
		else if (field.DataType.StartsWith("date"))
		{
			field.DataType = "time";
		}
		else if (field.DataType.StartsWith("varchar"))
		{
			field.DataType = "string";
		}
		else
		{
			throw new Exception("FFFFFFFF");
		}

		fields.Add(field);
	}

	return fields;
}

string GenerateYaml(List<FieldInfo> fields)
{
	var resultString = new StringBuilder();

	resultString.AppendLine($"cubes:");
	resultString.AppendLine($"  - name: DM_QES_ROLL_UP_PARAM_HRM2");
	resultString.AppendLine($"    title: Скалярные значения с уборочной группы ЛПЦ-2");
	resultString.AppendLine($"    data_source: qesdm");
	resultString.AppendLine($"    sql_table: DM_QES_FUR_PARAM_HRM2");
	resultString.AppendLine();

	foreach (var field in fields)
	{
		if (field.IsMetric)
		{
			resultString.AppendLine($"    measures:");
		}
	}

	return resultString.ToString();
}

string CleanName(string name)
{
	name = Regex.Replace(name, @"[^a-zA-Z0-9_]", "_");
	name = Regex.Replace(name, @"_+", "_");
	name = name.Trim('_');

	return name.ToUpper();
}

