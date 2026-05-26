using System.Text;
using ExcelToCubeConverter.Core.Models;

namespace ExcelToCubeConverter.Core;

/// <summary>
/// 
/// </summary>
public class CubeYamlGenerator
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="cube"></param>
	/// <returns></returns>
	public string Generate(CubeDefinition cube)
	{
		var yaml = new StringBuilder();
		
		var builder = new CubeYamlBuilder(cube);
		
		yaml.AppendLine(builder.Build());

		return yaml.ToString();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="cube"></param>
	/// <param name="filePath"></param>
	public void GenerateToFile(CubeDefinition cube, string filePath)
	{
		var yaml = Generate(cube);
		File.WriteAllTextAsync(filePath, yaml, Encoding.UTF8);
	}
}
