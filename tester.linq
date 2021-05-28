<Query Kind="Program">
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{
	var pathCSharp = "Export/dataCSharp.json";
	
	var pathPy = "Export/dataPy.json";
	
	var parent = new DirectoryInfo(Util.CurrentQueryPath).Parent.ToString();
	
	Dictionary<string, int> ToDic(string path) =>
				JToken.Parse(File.ReadAllText($"{parent}/{path}"))
					  .ToObject<Dictionary<string, int>>();

	ToDic(pathPy).SequenceEqual(ToDic(pathCSharp))
				 .Dump();
}

