using System.Text;
using ExcelToCubeConverter.Core.Models;

namespace ExcelToCubeConverter.Core.Services;

/// <summary>
/// Представляет генератор Yaml для CubeJS.
/// </summary>
public class YamlGenerator
{
	#region Public
	/// <summary>
	/// Генерирует конфигурацию Yaml куба.
	/// </summary>
	/// <param name="cube">Куб.</param>
	/// <returns>Конфигурация.</returns>
	public static string Generate(Cube cube)
	{
		var resultString = new StringBuilder();

		resultString.AppendLine("cubes:");
		resultString.AppendLine($"  - name: {cube.Name}");
		resultString.AppendLine($"    title: {cube.Title}");
		resultString.AppendLine($"    data_source: {cube.DataSource}");
		resultString.AppendLine($"    sql_table: {cube.SqlTable}");
		resultString.AppendLine();

		GenerateDimensions(resultString, cube);

		GenerateMeasures(resultString, cube);

		return resultString.ToString();
	}
	#endregion

	#region Private
	/// <summary>
	/// Генерирует dimensions.
	/// </summary>
	/// <param name="sb">Содержимое конфигурации куба.</param>
	/// <param name="cube">Куб.</param>
	private static void GenerateDimensions(StringBuilder sb, Cube cube)
	{
		sb.AppendLine("    dimensions:");

		foreach (var dimension in cube.Dimensions)
		{
			sb.AppendLine($"      - name: {dimension.Name}");
			sb.AppendLine($"        title: {dimension.Title}");
			sb.AppendLine($"        sql: '\"{dimension.Sql}\"'");
			sb.AppendLine($"        type: {dimension.Type}");

			if (dimension.IsPrimaryKey)
			{
				sb.AppendLine("        primary_key: true");
			}

			sb.AppendLine();
		}
	}

	/// <summary>
	/// Возвращает русский суффикс агрегации для title.
	/// </summary>
	private static string GetAggregationSuffix(string aggregation)
	{
		return aggregation.ToUpper() switch
		{
			"MIN" => ", мин",
			"MAX" => ", макс",
			"AVG" => ", средн",
			"SUM" => ", сум",
			"COUNT" => ", кол-во",
			_ => string.Empty
		};
	}

	/// <summary>
	/// Генерирует measures.
	/// </summary>
	/// <param name="sb">Содержимое конфигурации куба.</param>
	/// <param name="cube">Куб.</param>
	private static void GenerateMeasures(StringBuilder sb, Cube cube)
	{
		sb.AppendLine("    measures:");

		foreach (var measure in cube.Measures)
		{
			foreach (var aggregation in measure.Aggregations)
			{
				var suffix = GetAggregationSuffix(aggregation);

				sb.AppendLine($"      - name: {measure.Name}_{aggregation}");
				sb.AppendLine($"        title: {measure.Title}{suffix}");
				sb.AppendLine($"        sql: '\"{measure.Sql}\"'");
				sb.AppendLine($"        type: {aggregation.ToLower()}");
				sb.AppendLine();
			}
		}
	}
	#endregion
}
