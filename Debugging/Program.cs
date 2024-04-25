var value = 10;

int ValueAccepter(int value)
{
    return value++;
}

int value2 = ValueAccepter(value);

int y = 5;
void PrintValue()
{
    int y = 10;
    Console.WriteLine(y);
}
PrintValue();

Console.WriteLine($"{!(true && false)}");


string myString = "Hello";
string mySecondString = "World!";