string? inputString;
bool validUser = false;
do
{
    Console.WriteLine("Enter your role name (Administrator, Manager or User)");
    inputString = Console.ReadLine()?.Trim().ToLower();
    switch (inputString)
    {
        case "administrator":
        case "manager":
        case "user":
            Console.WriteLine($"Your input value ({inputString}) has been accepted");
            validUser = true;
            break;
        default:
            Console.WriteLine($"The role that you entered, '{inputString}', is not valid.");
            break;
    }

} while (!validUser);