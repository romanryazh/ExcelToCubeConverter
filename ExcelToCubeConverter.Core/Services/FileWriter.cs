namespace ExcelToCubeConverter.Core.Services;

/// <summary>
/// Представляет сервис сохранения файлов.
/// </summary>
public class FileWriter
{
	#region Public
	/// <summary>
	/// Сохраняет текстовый файл.
	/// </summary>
	public static void Write(string path, string content)
	{
		var directory = Path.GetDirectoryName(path);

		if (!string.IsNullOrWhiteSpace(directory))
		{
			Directory.CreateDirectory(directory);
		}

		File.WriteAllText(path, content);
	}
	#endregion
}
