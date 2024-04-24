int inputValue;
string? input;
bool validNumber = false;
bool operationCompleted = false;

do
{
    Console.WriteLine("Enter an integer value between 5 and 10.");
    input = Console.ReadLine();
    validNumber = int.TryParse(input, out inputValue);
    if (!validNumber)
    {
        Console.WriteLine("Sorry, you entered an invalid number. Please try again.");
    }
    else
    {
        if (inputValue < 5 || inputValue > 10)
        {
            Console.WriteLine($"You entered {inputValue}. Please enter a number between 5 and 10.");
        }
        else
        {
            Console.WriteLine($"Your input value ({inputValue}) has been accepted.");
            operationCompleted = true;
        }
    }
} while (!operationCompleted);