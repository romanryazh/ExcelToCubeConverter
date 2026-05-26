namespace ExcelToCubeConverter.Core.Models;

public class ParserOptions
{
	public int HeaderRow
	{
		get;
		init;
	} = 1;

	public int DataStartRow
	{
		get;
		init;
	} = 3;

	public string? SheetName
	{
		get;
		init;
	}
}
