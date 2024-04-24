/* Random dice = new();
int roll1 = dice.Next();
int roll2 = dice.Next(101);
int roll3 = dice.Next(102, 120);


Console.WriteLine($"First Roll: {roll1}");
Console.WriteLine($"Second Roll: {roll2}");
Console.WriteLine($"Third Roll: {roll3}");


int firstValue = 500;
int secondValue = 600;
int largestValue = Math.Max(firstValue, secondValue);

Console.WriteLine(largestValue);

Declarer en ny instance av Random som dice.
Random dice = new();

Caller dice.Next() for tre variabler.

int roll1 = dice.Next(1, 7);
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);

int total = roll1 + roll2 + roll3;

Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");
if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
{
    if ((roll1 == roll2) && (roll2 == roll3))
    {
        total += 6;
        Console.WriteLine($"You rolled triples! +6 bonus points! Current total: {total}");
    }
    else
    {
        total += 2;
        Console.WriteLine($"You rolled doubles! +2 bonus points! Current total: {total}");
    }
}


if (total >= 16)
{
    Console.WriteLine("You win a new car!");
}
else if (total >= 10)
{
    Console.WriteLine("You win a new laptop!");
}
else if (total == 7)
{
    Console.WriteLine("You win a trip for two!");
}
else
{
    Console.WriteLine("You win a kitten!");
}

Random random = new();
int daysUntilExpiration = random.Next(12);
int discountPercentage;


if (daysUntilExpiration == 0)
{
    Console.WriteLine("Your subscription has expired.");
}
else if (daysUntilExpiration == 1)
{
    discountPercentage = 20;
    Console.WriteLine($"Your subscription expires within a day!\nRenew now and save{discountPercentage}%");
}
else if (daysUntilExpiration < 6)
{
    discountPercentage = 10;
    Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.\nRenew now and save {discountPercentage}%");
}
else if (daysUntilExpiration < 11)
{
    Console.WriteLine("Your subscription expires soon. Renew now!");
}

string[] fraudulentOrderIDs = { "A123", "B456", "C789" };
Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "F000";

Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");

Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");


int[] inventory = { 200, 450, 700, 175, 250 };
int sum = 0;

foreach (int item in inventory)
{
    sum += item;
}

Console.WriteLine($"Sum of all items is: {sum}");

string[] fraudulentOrderIDs = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };

foreach (string Id in fraudulentOrderIDs)
{
    if (Id.StartsWith('B'))
    {
        Console.WriteLine(Id);
    }
}

int[] numbers = { 4, 8, 15, 16, 23, 42 };
int total = 0;
bool found = false;
foreach (int number in numbers)
{
    total += number;
    if (number == 42)
    {
        found = true;
    }
}
if (found)
{
    Console.WriteLine("Set contains 42");
}
Console.WriteLine($"Total: {total}");

int fistInt = 1;
if (fistInt > 0)
{
    int secondInt = 8;
    fistInt += secondInt;
}
Console.WriteLine(fistInt);



*/