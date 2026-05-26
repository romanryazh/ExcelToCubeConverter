namespace ExcelToCubeConverter.Core.Models.Settings;

/// <summary>
/// Представляет настройки Excel.
/// </summary>
public class ExcelSettings
{
	#region Properties
	/// <summary>
	/// Возвращает строку начала данных.
	/// </summary>
	public int DataStartRow
	{
		get;
		set;
	}

	/// <summary>
	/// Возвращает путь к Excel файлу.
	/// </summary>
	public string FilePath
	{
		get;
		set;
	} = string.Empty;

	/// <summary>
	/// Возвращает номер строки заголовков.
	/// </summary>
	public int HeaderRow
	{
		get;
		set;
	}

	/// <summary>
	/// Возвращает индекс листа Excel.
	/// </summary>
	public int WorksheetIndex
	{
		get;
		set;
	}
	#endregion
}
