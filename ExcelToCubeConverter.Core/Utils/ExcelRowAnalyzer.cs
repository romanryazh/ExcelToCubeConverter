namespace ExcelToCubeConverter.Core.Utils;

/// <summary>
/// Представляет анализатор строк Excel.
/// </summary>
public static class ExcelRowAnalyzer
{
	#region Public
	/// <summary>
	/// Проверяет, является ли строка заголовком куба.
	/// </summary>
	public static bool IsCubeRow(List<string> row)
	{
		if (row.Count < 2)
		{
			return false;
		}

		var firstFilled = !string.IsNullOrWhiteSpace(row[0]);

		var secondFilled = !string.IsNullOrWhiteSpace(row[1]);

		var othersEmpty = row.Skip(2)
							 .All(string.IsNullOrWhiteSpace);

		return firstFilled && secondFilled && othersEmpty;
	}

	/// <summary>
	/// Проверяет, является ли строка описанием поля.
	/// </summary>
	public static bool IsFieldRow(List<string> row)
	{
		if (row.Count < 4)
		{
			return false;
		}

		return !string.IsNullOrWhiteSpace(row[0]) && !string.IsNullOrWhiteSpace(row[1]) && !string.IsNullOrWhiteSpace(row[2]) && !string.IsNullOrWhiteSpace(row[3]);
	}
	#endregion
}
