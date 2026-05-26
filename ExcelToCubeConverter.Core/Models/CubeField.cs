namespace ExcelToCubeConverter.Core.Models;

/// <summary>
/// Представляет поле CubeJS.
/// </summary>
public class CubeField
{
	#region Properties
	/// <summary>
	/// Возвращает список агрегаций.
	/// </summary>
	public List<string> Aggregations
	{
		get;
		set;
	} = [];

	/// <summary>
	/// Возвращает признак primary key.
	/// </summary>
	public bool IsPrimaryKey
	{
		get;
		set;
	}

	/// <summary>
	/// Возвращает название поля.
	/// </summary>
	public string Name
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает SQL выражение поля.
	/// </summary>
	public string Sql
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает заголовок поля.
	/// </summary>
	public string Title
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает тип CubeJS.
	/// </summary>
	public string Type
	{
		get;
		set;
	} = string.Empty;
	#endregion
}
