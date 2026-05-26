using ExcelToCubeConverter.Core.Mapping;
using ExcelToCubeConverter.Core.Models;
using ExcelToCubeConverter.Core.Utils;

namespace ExcelToCubeConverter.Core.Services;

/// <summary>
/// Представляет строителя Cube модели из Excel строк.
/// </summary>
public class CubeBuilder
{
	#region Public
	/// <summary>
	/// Создаёт список кубов.
	/// </summary>
	/// <param name="rows">Строки Excel.</param>
	/// <param name="dataSource">Источник данных.</param>
	/// <returns>Список кубов.</returns>
	public static List<Cube> Build(List<ExcelRow> rows, string dataSource)
	{
		var cubes = new List<Cube>();

		Cube? cube = null;

		foreach (var row in rows)
		{
			var rawRow = new List<string>
			{
				row.FieldName,
				row.CubeTitle,
				row.DataType,
				row.Category,
				row.Aggregations,
				row.JoinExpression
			};

			if (ExcelRowAnalyzer.IsCubeRow(rawRow))
			{
				cube = CreateCube(row, dataSource);

				cubes.Add(cube);

				continue;
			}

			if (cube == null)
			{
				continue;
			}

			if (!ExcelRowAnalyzer.IsFieldRow(rawRow))
			{
				continue;
			}

			var field = CreateField(row);

			if (row.Category.Equals("Dimension", StringComparison.OrdinalIgnoreCase))
			{
				cube.Dimensions.Add(field);
			}
			else if (row.Category.Equals("Metric", StringComparison.OrdinalIgnoreCase))
			{
				cube.Measures.Add(field);
			}
		}

		return cubes;
	}
	#endregion

	#region Private
	/// <summary>
	/// Создаёт куб.
	/// </summary>
	private static Cube CreateCube(ExcelRow row, string dataSource) =>
		new()
		{
			Name = row.FieldName,
			Title = row.CubeTitle,
			SqlTable = row.FieldName,
			DataSource = dataSource
		};

	/// <summary>
	/// Создаёт поле куба.
	/// </summary>
	private static CubeField CreateField(ExcelRow row) =>
		new()
		{
			Name = row.FieldName,
			Title = row.CubeTitle,
			Sql = row.CubeTitle,
			Type = TypeMapper.Map(row.DataType),

			Aggregations = AggregationMapper.Parse(row.Aggregations),

			IsPrimaryKey = row.FieldName.Equals("PRODUCT_ID", StringComparison.OrdinalIgnoreCase)
		};
	#endregion
}
