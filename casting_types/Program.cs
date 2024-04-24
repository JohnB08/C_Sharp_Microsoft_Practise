int first = 2;
string second = "4";
string result = first + second;
Console.WriteLine(result);

int myInt = 3;
decimal myDecimal = myInt;
Console.WriteLine($"int: {myInt}\ndecimal: {myDecimal}");

myDecimal = 3.14m;
myInt = (int)myDecimal;

Console.WriteLine($"int: {myInt}\ndecimal: {myDecimal}");

int secondInt = 7;
string numberMessage = first.ToString() + secondInt.ToString();

Console.WriteLine(numberMessage);

string firstString = "2";

int sum = int.Parse(firstString) + int.Parse(second);
Console.WriteLine(sum);

string stringValue = "102";
int parseResult = 0;
if (int.TryParse(stringValue, out parseResult))
{
    Console.WriteLine($"Successfully parsed: {parseResult}");
}
else
{
    Console.WriteLine("Parse Failed");
}