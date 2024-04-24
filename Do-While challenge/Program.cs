int heroHealth = 10;
int monsterHealth = 10;
Random attack = new();
bool gameOver = false;
int damage;

do
{
    damage = attack.Next(1, 10);
    monsterHealth -= damage;
    Console.WriteLine($"Monster was damage and lost {damage} health, and now has {monsterHealth} health.");
    if (monsterHealth < 0)
    {
        Console.WriteLine("Hero wins!");
        break;
    }
    damage = attack.Next(1, 10);
    heroHealth -= damage;
    Console.WriteLine($"Hero was damaged and lost {damage} health, and now has {heroHealth} health.");
    if (heroHealth < 0)
    {
        Console.WriteLine("Monster wins!");
        break;
    }
} while (gameOver == false);