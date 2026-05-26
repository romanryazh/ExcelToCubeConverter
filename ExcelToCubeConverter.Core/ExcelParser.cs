using ExcelToCubeConverter.Core.Enum;
using ExcelToCubeConverter.Core.Models;
using OfficeOpenXml;

namespace ExcelToCubeConverter.Core;

public class ExcelParser
{
	public void Parse(string filePath, ParserOptions options)
	{
		var fields = new List<Models.FieldInfo>();

		// using var package = new ExcelPackage(new FileInfo(excelFilePath));
		//
		// var worksheet = package.Workbook.Worksheets[0];
	}

	public FieldInfo? ParseRow()
	{
		return null;
	}

	public DataType ParseDataType(string value) =>
		value?.ToLower() switch
		{
			"number" or "decimal" or "int" or "number(18)" => DataType.Number,
			"date" or "datetime" or "timestamp" => DataType.DateTime,
			"varchar2" or "string" or "text" => DataType.String,
			_ => DataType.String
		};

	private AggregationType? ParseAggregation(string value) =>
		value?.ToLower() switch
		{
			"min" => AggregationType.Min,
			"max" => AggregationType.Max,
			"avg" => AggregationType.Avg,
			"sum" => AggregationType.Sum,
			"count" => AggregationType.Count,
			_ => null
		};

	private FieldCategory ParseCategory(string value) => value?.Contains("Metric", StringComparison.OrdinalIgnoreCase) == true ? FieldCategory.Metric : FieldCategory.Dimension;

	private string CleanName(string name)
	{
		var cleaned = System.Text.RegularExpressions.Regex.Replace(name, @"[^a-zA-Z0-9_]", "_");
		cleaned = System.Text.RegularExpressions.Regex.Replace(cleaned, @"_+", "_");
		return cleaned.Trim('_')
					  .ToUpperInvariant();
	}
}
