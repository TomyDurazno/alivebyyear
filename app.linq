<Query Kind="Program">
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var fileName = "Data/Fechas Personas Una Linea.txt";	
	var outputName = "Data/dataCSharp.json";
	
	var parent = new DirectoryInfo(Util.CurrentQueryPath).Parent.ToString();

	var line = File.ReadAllText($"{parent}/{fileName}");

	var elements = JToken.Parse(line).ToObject<List<Person>>();

	var dic = new Dictionary<int, int>();

	foreach (var i in Enumerable.Range(1900, 101))
		dic.Add(i, ByYear(elements, i).Count);

	var json = JsonConvert.SerializeObject(dic, Newtonsoft.Json.Formatting.None);

	File.WriteAllText($"{parent}/{outputName}", json);
}

List<Person> ByYear(List<Person> people, int year)
{
	var alive = new List<Person>();
	
	foreach (var person in people)
	{
		var dates = person.Dates;
		var birthYear = Convert.ToInt32(dates.birth.Split('-')[0]);
		var deathYear = Convert.ToInt32(dates.death.Split('-')[0]);
		
		if (year >= birthYear && year <= deathYear)
			alive.Add(person);
	}
	
	return alive;
}

public class Dates
{
	public string birth { get; set; }
	public string death { get; set; }
}

public class Person
{
	public string Name { get; set; }
	public Dates Dates { get; set; }
}
