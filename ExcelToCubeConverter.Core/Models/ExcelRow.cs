namespace ExcelToCubeConverter.Core.Models;

/// <summary>
/// Представляет строку Excel файла.
/// </summary>
public class ExcelRow
{
	#region Properties
	/// <summary>
	/// Возвращает список агрегаций.
	/// </summary>
	public string Aggregations
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает тип поля: Dimension или Metric.
	/// </summary>
	public string Category
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает значение колонки "Название в кубе".
	/// </summary>
	public string CubeTitle
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает тип данных.
	/// </summary>
	public string DataType
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает значение колонки "Поля".
	/// </summary>
	/// б
	public string FieldName
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает поля для связи.
	/// </summary>
	public string JoinExpression
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает номер строки Excel.
	/// </summary>
	public int RowNumber
	{
		get;
		set;
	}
	#endregion
}
