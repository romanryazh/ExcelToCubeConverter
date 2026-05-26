using OfficeOpenXml;

namespace ExcelToCubeConverter.Core.Services;

/// <summary>
/// Представляет сервис чтения Excel файла.
/// </summary>
public class ExcelReader
{
	#region Public
	/// <summary>
	/// Считывает Excel лист в список строк.
	/// </summary>
	public static List<List<string>> Read(string filePath, int worksheetIndex, int startRow)
	{
		ExcelPackage.License.SetNonCommercialPersonal("Mee");

		var result = new List<List<string>>();

		using var package = new ExcelPackage(new FileInfo(filePath));

		var worksheet = package.Workbook.Worksheets[worksheetIndex];

		if (worksheet.Dimension == null)
		{
			return result;
		}

		var rowCount = worksheet.Dimension.Rows;
		var colCount = worksheet.Dimension.Columns;

		for (var row = startRow; row <= rowCount; row++)
		{
			var rowData = new List<string>();

			for (var col = 1; col <= colCount; col++)
			{
				var value = worksheet.Cells[row, col]
									 .Text?.Trim() ??
							string.Empty;

				rowData.Add(value);
			}

			result.Add(rowData);
		}

		return result;
	}
	#endregion
}
