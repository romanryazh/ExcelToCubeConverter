using System.Text;
using ExcelToCubeConverter.Core.Models;

namespace ExcelToCubeConverter.Core;

public class CubeYamlBuilder(CubeDefinition cubeDefinition)
{
	#region Data
	#region Fields
	private readonly CubeDefinition _cube = cubeDefinition;
	#endregion
	#endregion

	#region Public
	public string Build()
	{
		var sb = new StringBuilder();

		sb.AppendLine("cubes:");
		AppendCubeHeader(sb);
		sb.AppendLine();

		AppendJoins(sb);
		
		AppendDimensions(sb);
		
		AppendMeasures(sb);

		return sb.ToString();
	}
	#endregion

	#region Private
	private void AppendCubeHeader(StringBuilder sb)
	{
		sb.AppendLine($"  - name: {_cube.Name}");
		sb.AppendLine($"    title: {_cube.Title}");
		sb.AppendLine($"    data_source: {_cube.DataSource}");
		sb.AppendLine($"    sql_table: {_cube.SqlTable}");
	}

	private void AppendDimensions(StringBuilder sb)
	{
		sb.AppendLine();
		sb.AppendLine("    dimensions:");
		
		foreach (var dim in _cube.Dimensions)
		{
			sb.AppendLine($"      - name: {dim.CubeName}");
			sb.AppendLine($"        title: {dim.Title}");
			sb.AppendLine($"        sql: \"{dim.SqlColumn}\"");
			sb.AppendLine($"        type: {dim.CubeJsType}");
                
			if (dim.IsPrimaryKey)
			{
				sb.AppendLine($"        primary_key: true");
			}

			sb.AppendLine();
		}
	}

	private void AppendJoins(StringBuilder sb)
	{
	}

	private void AppendMeasures(StringBuilder sb)
	{
		sb.AppendLine("    measures:");
            
		foreach (var measure in _cube.Measures)
		{
			sb.AppendLine($"      - name: {measure.CubeName}");
			sb.AppendLine($"        title: {measure.Title}");
			sb.AppendLine($"        sql: \"{measure.SqlColumn}\"");
			sb.AppendLine($"        type: {measure.Aggregation!.ToLower()}");
			sb.AppendLine();
		}
	}
	#endregion
}
