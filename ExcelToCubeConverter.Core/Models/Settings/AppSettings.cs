namespace ExcelToCubeConverter.Core.Models.Settings;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
	#region Properties
	/// <summary>
	/// Возвращает настройки Cube.
	/// </summary>
	public CubeSettings Cube
	{
		get;
		set;
	} = new();

	/// <summary>
	/// Возвращает настройки Excel.
	/// </summary>
	public ExcelSettings Excel
	{
		get;
		set;
	} = new();
	#endregion
}
