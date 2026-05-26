namespace ExcelToCubeConverter.Core.Models.Settings;

/// <summary>
/// Представляет настройки Cube.
/// </summary>
public class CubeSettings
{
	#region Properties
	/// <summary>
	/// Возвращает название data source.
	/// </summary>
	public string DataSource
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает путь сохранения файла.
	/// </summary>
	public string OutputPath
	{
		get;
		set;
	} = string.Empty;
	#endregion
}
