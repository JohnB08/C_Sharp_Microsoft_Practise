/* int a = 3;
int b = 4;
int c = 0;

Multiply(a, b, c);
Console.WriteLine($"global statement: {a} x {b} = {c}");

void Multiply(int a, int b, int c)
{
    c = a * b;
    Console.WriteLine($"inside multiply method: {a} x {b} = {c}");
} */

/* int[] array = { 1, 2, 3, 4, 5 };
PrintArray(array);
Clear(array);
PrintArray(array);

void PrintArray(int[] array)
{
    foreach (int a in array)
    {
        Console.Write($"{a} ");
    }
    Console.WriteLine();
}
void Clear(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = 0;
    }
} */

/* string status = "Healthy";

Console.WriteLine($"Start: {status}");
SetHealth(false);
Console.WriteLine($"End: {status}");

void SetHealth(bool isHealthy)
{
    status = isHealthy ? "Healthy" : "Unhealthy";
    Console.WriteLine($"Middle: {status}");
} */

/* string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
string[] rsvps = new string[10];
int count = 0;

RSVP("Rebecca", 1);
RSVP("Nadia", 2, "Nuts");
RSVP("Linh", 2, inviteOnly: false);
RSVP("Tony", 1, "Jackfruit");
RSVP("Noor", 4, inviteOnly: false);
RSVP("Jonte", 2, "Stone fruit", false);
ShowRSVPs();


void RSVP(string name, int partySize, string allergies = "none", bool inviteOnly = true)
{
    if (inviteOnly)
    {
        bool found = false;
        foreach (string guest in guestList)
        {
            if (guest.Equals(name))
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Sorry, {name} is not on the guest list");
            return;
        }
    }
    rsvps[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
    count++;
}

void ShowRSVPs()
{
    Console.WriteLine("\nTotal RSVPs: ");
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(rsvps[i]);
    }
} */

string[,] corporate =
{
    {"Robert", "Bavin"}, {"Simon", "Bright"},
    {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
    {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};
string internalDomain = "contoso.com";

string[,] external =
{
    {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
    {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "hayworth.com";
string email = "";

for (int i = 0; i < corporate.GetLength(0); i++)
{
    email = corporate[i, 0].ToLower().Substring(0, 2) + corporate[i, 1].ToLower() + "@" + internalDomain;
    Console.WriteLine(email);

}
for (int i = 0; i < external.GetLength(0); i++)
{
    email = external[i, 0].ToLower().Substring(0, 2) + external[i, 1].ToLower() + "@" + externalDomain;
    Console.WriteLine(email);

}
