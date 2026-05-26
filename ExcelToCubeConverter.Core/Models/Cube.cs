namespace ExcelToCubeConverter.Core.Models;

/// <summary>
/// Представляет данные для CubeJS куба.
/// </summary>
public class Cube
{
	#region Properties
	/// <summary>
	/// Возвращает источник данных.
	/// </summary>
	public string DataSource
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает Dimensions куба.
	/// </summary>
	public List<CubeField> Dimensions
	{
		get;
		set;
	} = [];

	/// <summary>
	/// Возвращает Joins куба.
	/// </summary>
	public List<CubeJoin> Joins
	{
		get;
		set;
	} = [];

	/// <summary>
	/// Возвращает Measures куба.
	/// </summary>
	public List<CubeField> Measures
	{
		get;
		set;
	} = [];

	/// <summary>
	/// Возвращает название куба.
	/// </summary>
	public string Name
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает SQL таблицу.
	/// </summary>
	public string SqlTable
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает отображаемое название куба.
	/// </summary>
	public string Title
	{
		get;
		set;
	} = string.Empty;
	#endregion
}
