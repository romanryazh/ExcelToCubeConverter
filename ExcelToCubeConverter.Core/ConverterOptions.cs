namespace ExcelToCubeConverter.Core;

/// <summary>
/// </summary>
public class ConverterOptions
{
	#region Properties
	/// <summary>
	/// </summary>
	public string InputFile
	{
		get;
		set;
	} = null!;

	/// <summary>
	/// </summary>
	public string OutputFile
	{
		get;
		set;
	} = null!;

	/// <summary>
	/// </summary>
	public string SheetName
	{
		get;
		set;
	} = null!;

	/// <summary>
	/// </summary>
	public int StartRow
	{
		get;
		set;
	} = 2;
	#endregion
}
