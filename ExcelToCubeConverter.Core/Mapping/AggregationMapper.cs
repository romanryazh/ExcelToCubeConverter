namespace ExcelToCubeConverter.Core.Mapping;

/// <summary>
/// Представляет маппер агрегаций.
/// </summary>
public static class AggregationMapper
{
	/// <summary>
	/// Разбирает строку агрегаций.
	/// </summary>
	/// <param name="aggregations">Агрегации.</param>
	/// <returns>Список агрегаций.</returns>
	public static List<string> Parse(string aggregations)
	{
		if (string.IsNullOrWhiteSpace(aggregations))
		{
			return [];
		}

		return aggregations.Split(',', StringSplitOptions.RemoveEmptyEntries)
						   .Select(x => x.Trim()
										 .ToUpper())
						   .ToList();
	}
}
