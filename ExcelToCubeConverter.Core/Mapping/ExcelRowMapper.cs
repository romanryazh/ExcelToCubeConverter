using ExcelToCubeConverter.Core.Models;

namespace ExcelToCubeConverter.Core.Mapping;

/// <summary>
/// Представляет маппер для преобразования raw строки Excel в ExcelRow.
/// </summary>
public class ExcelRowMapper
{
	#region Public
	/// <summary>
	/// Преобразует строку Excel.
	/// </summary>
	public static ExcelRow Map(List<string> row, int rowNumber) =>
		new()
		{
			RowNumber = rowNumber,
			FieldName = GetValue(row, 0),
			CubeTitle = GetValue(row, 1),
			DataType = GetValue(row, 2),
			Category = GetValue(row, 3),
			Aggregations = GetValue(row, 4),
			JoinExpression = GetValue(row, 5)
		};
	#endregion

	#region Private
	/// <summary>
	/// Безопасное получение значения колонки.
	/// </summary>
	private static string GetValue(List<string> row, int index) => index >= row.Count ? string.Empty : row[index];
	#endregion
}
