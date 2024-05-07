Dictionary<string, string> nameDict = new Dictionary<string, string>{
    {"name", "Alice"},
    {"Age", "25"},
    {"City", "London"}
};

foreach (var key in nameDict)
{
    Console.WriteLine($"{key.Key}, {key.Value}");
}