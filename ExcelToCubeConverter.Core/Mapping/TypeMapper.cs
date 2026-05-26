using System.Text.RegularExpressions;

namespace ExcelToCubeConverter.Core.Mapping;

/// <summary>
/// Представляет маппер для типов БД в типы CubeJS.
/// </summary>
public static class TypeMapper
{
	#region Public
	/// <summary>
	/// Преобразует тип БД в тип CubeJS.
	/// </summary>
	/// <param name="sourceType">Исходный тип.</param>
	/// <returns>Преобразованный тип.</returns>
	public static string Map(string sourceType)
	{
		if (string.IsNullOrWhiteSpace(sourceType))
		{
			return "string";
		}

		var normalizedType = Normalize(sourceType);

		return normalizedType switch
		{
			"number" or "numeric" or "decimal" or "integer" or "int" => "number",
			"date" or "datetime" or "timestamp" => "time",
			"varchar2" or "varchar" or "char" or "text" => "string",
			_ => "string"
		};
	}
	#endregion

	#region Private
	/// <summary>
	/// Нормализует тип БД.
	/// </summary>
	/// <param name="sourceType">Исходный тип.</param>
	/// <returns>Нормализованный тип.</returns>
	private static string Normalize(string sourceType)
	{
		var normalized = sourceType.Trim()
								   .ToLower();
		normalized = Regex.Replace(normalized, @"\(.*?\)", "");

		normalized = normalized.Replace("char", "")
							   .Trim();

		return normalized;
	}
	#endregion
}
