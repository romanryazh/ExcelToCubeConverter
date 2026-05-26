using System.Text.Json;
using ExcelToCubeConverter.Core.Mapping;
using ExcelToCubeConverter.Core.Models;
using ExcelToCubeConverter.Core.Models.Settings;
using ExcelToCubeConverter.Core.Services;

Console.WriteLine("+--------------------------------------------------+");
Console.WriteLine("|    Вы используете Excel To CubeJS Converter      |");
Console.WriteLine("+--------------------------------------------------+");

const string settingsFileName = "appsettings.json";

if (!File.Exists(settingsFileName))
{
	Console.WriteLine("Ошибка: Не удалось загрузить файл appsettings.json.");
	Console.WriteLine("Причина: Файл настроек не найден.");

	return;
}

AppSettings? settings;

try
{
	var settingsJson = File.ReadAllText(settingsFileName);

	settings = JsonSerializer.Deserialize<AppSettings>(settingsJson);
}
catch (Exception ex)
{
	Console.WriteLine($"Ошибка: {ex.Message}");

	return;
}

if (settings == null)
{
	Console.WriteLine("Ошибка: Не удалось загрузить файл appsettings.json.");

	return;
}

Console.WriteLine("Процесс: Чтение Excel файла...");

var rawRows = ExcelReader.Read(settings.Excel.FilePath, settings.Excel.WorksheetIndex, settings.Excel.DataStartRow);

Console.WriteLine($"Результат: Считано строк: {rawRows.Count}");

var excelRows = new List<ExcelRow>();

var rowNumber = settings.Excel.DataStartRow;

foreach (var row in rawRows)
{
	var mappedRow = ExcelRowMapper.Map(row, rowNumber);

	excelRows.Add(mappedRow);

	rowNumber++;
}

Console.WriteLine("Процесс: Построение кубов...");

var cubes = CubeBuilder.Build(excelRows, settings.Cube.DataSource);

Console.WriteLine($"Инфо: Найдено кубов: {cubes.Count}");

foreach (var cube in cubes)
{
	Console.WriteLine($"Процесс: Генерация YAML: {cube.Name}");
	
	var yaml = YamlGenerator.Generate(cube);

	var outputPath = settings.Cube.OutputPath;
	
	FileWriter.Write(outputPath, yaml);

	Console.WriteLine($"Результат: Файл сохранён: {outputPath}");
}

Console.WriteLine();
Console.WriteLine("Готово.");