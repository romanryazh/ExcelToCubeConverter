namespace ExcelToCubeConverter.Core.Models;

public class CubeDefinition
{
	public string Name { get; set; }
	
	public string Title { get; set; }
	
	public string DataSource { get; set; }
	
	public string SqlTable { get; set; }
	
	public List<FieldInfo> Dimensions { get; set; }
	
	public List<FieldInfo> Measures { get; set; }
}
