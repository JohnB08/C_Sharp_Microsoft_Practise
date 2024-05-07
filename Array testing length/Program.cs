// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



int[] myInt = new int[5];

for (int i = 0; i < myInt.Length; i++)
{
    myInt[i] = i;
}
foreach (int i in myInt)
{
    Console.WriteLine(i);
}


string myString = "42";

int parsedInt;

bool parsedSucccess;

parsedSucccess = int.TryParse(myString, out parsedInt);
if (parsedSucccess)
{
    Console.WriteLine(parsedInt);
}
else
{
    Console.WriteLine("Oooops");
}

string? Input;

int a;

Console.WriteLine("Want to check if a number is even?");

Input = Console.ReadLine();

if (Input != null)
{
    if (int.TryParse(Input, out a))
    {
        if (IsEven(a))
        {
            Console.WriteLine($"Your number {a} is even!");
        }
        else
        {
            Console.WriteLine($"Your number {a} is odd!");
        }
    }
    else
    {
        Console.WriteLine("You didn't input a number dumbass.");
    }
}
else
{
    Console.WriteLine("You didn't input a number dumbass.");
}


bool IsEven(int a)
{
    return (a & 1) == 0;
}


