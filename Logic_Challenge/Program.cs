string permission = "Manager";
int level = 19;


if (permission == "Admin" && level > 55)
{
    Console.WriteLine("Welcome Super Admin user.");
}
else if (permission == "Admin" && level <= 55)
{
    Console.WriteLine("Welcome Admin user.");
}
else if (permission == "Manager" && level > 20)
{
    Console.WriteLine("Contact an Admin for access.");
}
else
{
    Console.WriteLine("You do not have sufficient priviliges");
}