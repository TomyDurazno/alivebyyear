<Query Kind="Program">
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{
	var parent = new DirectoryInfo(Util.CurrentQueryPath).Parent.ToString();
	
	Dictionary<string, int> ToDic(string path) =>
				JToken.Parse(File.ReadAllText($"{parent}/{path}"))
					  .ToObject<Dictionary<string, int>>();

	ToDic("Data/dataPy.json").SequenceEqual(ToDic("Data/dataCSharp.json"))
						.Dump();
}

