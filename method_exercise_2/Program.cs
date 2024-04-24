
string[] ipv4InputArray = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };

bool validLength = false;
bool validZeroes = false;
bool validRange = false;

foreach (string ipv4Input in ipv4InputArray)
{

    ValidateLength();
    ValidateRange();
    ValidateZeroes();

    if (validLength && validZeroes && validRange)
    {
        Console.WriteLine($"{ipv4Input} is a valid IPv4 Adress");
    }
    else
    {
        Console.WriteLine($"{ipv4Input} is invalid.");
    }

    void ValidateLength()
    {
        string[] adress = ipv4Input.Split(".", StringSplitOptions.RemoveEmptyEntries);
        validLength = adress.Length == 4;
    };
    void ValidateZeroes()
    {
        string[] adress = ipv4Input.Split(".", StringSplitOptions.RemoveEmptyEntries);
        foreach (string number in adress)
        {
            if (number.Length > 1 && number.StartsWith("0"))
            {
                validZeroes = false;
                return;
            }
        }
        validZeroes = true;
    };
    void ValidateRange()
    {
        string[] adress = ipv4Input.Split(".", StringSplitOptions.RemoveEmptyEntries);
        foreach (string number in adress)
        {
            int value = int.Parse(number);
            if (value < 0 || value > 255)
            {
                validRange = false;
                return;
            }
        }
        validRange = true;
    };
}


Random random = new Random();
int luck = random.Next(100);

string[] text = { "You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to" };
string[] good = { "look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!" };
string[] bad = { "fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life." };
string[] neutral = { "appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature." };
GetFortune();

void GetFortune()
{
    Console.WriteLine("A fortune teller whispers the following words:");
    string[] fortune = luck > 75 ? good : (luck < 25 ? bad : neutral);
    for (int i = 0; i < 4; i++)
    {
        Console.Write($"{text[i]} {fortune[i]} ");
    }
}