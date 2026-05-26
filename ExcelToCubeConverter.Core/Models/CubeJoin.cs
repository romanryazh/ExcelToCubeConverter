namespace ExcelToCubeConverter.Core.Models;

/// <summary>
/// Представляет Join CubeJS.
/// </summary>
public class CubeJoin
{
	#region Properties
	/// <summary>
	/// Возвращает название join.
	/// </summary>
	public string Name
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает тип связи.
	/// </summary>
	public string Relationship
	{
		get;
		set;
	} = "many_to_one";

	/// <summary>
	/// Возвращает SQL join выражение.
	/// </summary>
	public string Sql
	{
		get;
		set;
	} = string.Empty;
	#endregion
}
