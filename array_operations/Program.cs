using System.Globalization;

string[] pallets = { "B14", "A11", "B12", "A13" };

Console.WriteLine("Sorted...");
Array.Sort(pallets);
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
Console.WriteLine("\nReversed...");
Array.Reverse(pallets);
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}


Array.Clear(pallets, 0, 2);
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
Array.Resize(ref pallets, 6);
Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

pallets[4] = "C01";
pallets[5] = "C02";

foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
string result = new string(valueArray);
Console.WriteLine(result);

string pangram = "The quick brown fox jumps over the lazy dog";
string[] wordArray = pangram.Split(" ");
for (int i = 0; i < wordArray.Length; i++)
{
    char[] charArray = wordArray[i].ToCharArray();
    Array.Reverse(charArray);
    wordArray[i] = new string(charArray);
}
pangram = string.Join(" ", wordArray);
Console.WriteLine(pangram);