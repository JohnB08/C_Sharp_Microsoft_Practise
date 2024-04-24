Random random = new Random();
string? input;
Console.WriteLine("Would you like to play? (Y/N)");
if (ShouldPlay())
{
    PlayGame();
}

bool ShouldPlay()
{
    input = Console.ReadLine();
    if (input != null)
    {
        if (input == "Y")
        {
            return true;
        }
    }
    return false;
}
string WinOrLose(int a, int b)
{
    return a > b ? "You Lose!" : "You Win!";
}


void PlayGame()
{
    var play = true;

    while (play)
    {
        var target = random.Next(1, 10);
        var roll = random.Next(1, 10);

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(target, roll));
        Console.WriteLine("\nPlay again? (Y/N)");

        play = ShouldPlay();
    }
}