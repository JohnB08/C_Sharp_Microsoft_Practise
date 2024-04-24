Random random = new();

int current;

do
{
    current = random.Next(1, 11);
    if (current >= 8)
        Console.WriteLine(current);
} while (current != 7);
