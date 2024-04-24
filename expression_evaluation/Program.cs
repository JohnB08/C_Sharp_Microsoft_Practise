// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


/* Boolean expressions */

string myName = "John";

if (myName == "Luiz")
{
    Console.WriteLine("Wrong name!");
}

/* equality boolean expression == */

/* Inequality boolean expression != */


Console.WriteLine('a' == 'A');
Console.WriteLine("a" == "A");
Console.WriteLine(1 == 2);

string myValue = "a";
Console.WriteLine(myValue == "a");

string pangram = "The quick brown fox jumps over the lazy dog.";
Console.WriteLine(pangram.Contains("fox"));
Console.WriteLine(pangram.Contains("cow"));

/* Conditional Operator */

int saleAmount = 1001;
Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");


Random coinFlip = new();
Console.WriteLine($"I flip a coin!\n{(coinFlip.Next(0, 2) == 0 ? "Heads!" : "Tails!")}");