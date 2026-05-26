namespace ExcelToCubeConverter.Core.Models;

public class FieldInfo
{
	public string CubeName
	{
		get;
		set;
	} = null!;

	public string Title
	{
		get;
		set;
	} = null!;

	public string SqlColumn
	{
		get;
		set;
	}

	public string? CubeJsType
	{
		get;
		set;
	}

	public bool IsPrimaryKey
	{
		get;
		set;
	}

	public string? Aggregation
	{
		get;
		set;
	}
}
