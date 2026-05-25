namespace ExcelToCubeConverter.Core;

public class FieldInfo
{
	#region Properties
	public string? Aggregation
	{
		get;
		set;
	}

	public string CubeName
	{
		get;
		set;
	}

	public string DataType
	{
		get;
		set;
	}

	public string FieldName
	{
		get;
		set;
	}

	public bool IsMetric
	{
		get;
		set;
	}

	public string SqlColumn
	{
		get;
		init;
	}
	#endregion
}
