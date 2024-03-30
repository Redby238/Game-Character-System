
class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Character(string name, int health, int attack, int defense)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
    }
   
    public virtual int Atack(Character target)
    {
        if (Attack > 0) { 
             int damage = Math.Max(Attack - target.Defense, 0);
            target.Health -= damage;
            Console.WriteLine($"\n{Name} attacks {target.Name} for {Attack} damage!");
            if (target.Health <= 0) Console.WriteLine($"{target.Name} has been defeated!");
        }
        return Health;
    }
    public virtual void Defend() { Console.WriteLine($"{Name} is defending!"); }

}

class Warrior : Character
{
    public Warrior(string name, int health, int attack, int defense) : base(name, health, attack, defense)
    {
        {
           
        }
    }
    public override void Defend()
    {
        base.Defend();
        Defense += 5;
    }


}

class Mage : Character
{
    public Mage(string name, int health, int attack, int defense) : base(name, health, attack, defense)
    {
  
    }
    public void CastSpell(Character target)
    {
        Console.WriteLine($"{Name} is charging a spell!");
        target.Health -= 10;
    }
     public sealed override void Defend()
    {
        base.Defend();
        Defense += 2; 
    }
}

class Dragon : Character
{
    public Dragon(string name, int health, int attack, int defense) : base(name, health, attack, defense)
    {

    }
    public void BreatheFire(Character target)
    {
        Console.WriteLine("The dragon is ready to breathe with fire!");
    }

    public override int Atack(Character target)
    {
        Console.WriteLine($"{Name} breathes fire at {target.Name}!");

        int damage = Math.Max(Attack - target.Defense, 0) * 2; 
        target.Health -= damage;
        return Health;

    }
}

class Game
{
   static public void DrawImage()
    {
        Console.WriteLine("              / \\");
        Console.WriteLine("             /___\\");
        Console.WriteLine("            //0 0\\\\");
        Console.WriteLine("           //  \\// \\\\");
        Console.WriteLine("         __\\    //   /__");
        Console.WriteLine("        /  /\\  //\\  /\\  \\");
        Console.WriteLine("       /  /  \\/  \\/  \\  \\");
        Console.WriteLine("      /  /           \\  \\");
        Console.WriteLine("     /__/             \\__\\");
        Console.WriteLine("     |  |             |  |");
        Console.WriteLine("     |  |_____________|  |");
        Console.WriteLine("     |  |             |  |");
        Console.WriteLine("     |__|             |__|");
        Console.WriteLine("    //_/             \\_\\\\");
        Console.WriteLine("   // /               \\ \\");
        Console.WriteLine("  |/ /                 \\ \\|");
        Console.WriteLine("  /_/                   \\_\\");
    }
    static public void DrawImageS()
    {
        Console.WriteLine("        _  /\\  _");
        Console.WriteLine("      /  \\/  \\/  \\");
        Console.WriteLine("    /  /\\    /\\  \\");
        Console.WriteLine("  /  /  \\____/  \\  \\");
        Console.WriteLine(" /__|   /\\  /\\   |__\\");
        Console.WriteLine(" |__/\\__|  ||  |__|__|");
        Console.WriteLine(" |__||  |__||__|  ||__|");
        Console.WriteLine(" |__||__|  __  |__||__|");
        Console.WriteLine(" |__|__|     |__|__|__|");
        Console.WriteLine("  \\_|__|     |__|__|_/");
        Console.WriteLine("     |_________|");
        Console.WriteLine("     |         |");
        Console.WriteLine("     |         |");
        Console.WriteLine("     |_________|");
        Console.WriteLine("     \\_________/");
    }
    static void Main(string[] args)
    {
        
        string dragonImage = @"                                                     
      /\    /\
     /  \  /  \
    /    \/    \
   |           | 
   \           /
    \         /
     \_______/
      /       \
     /         \
    /           \
   /_____________";
        var warrior = new Warrior("Vasiliy", 100, 5, 15);
        var mage = new Mage("Antonit", 85, 15, 5);
        var dragon = new Dragon("Zebra ya ebu", 110, 20, 20);

        bool gameEnds = false;
        Character currentCharacter = null;

        while (!gameEnds)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("The Game begins!");

            if (currentCharacter == null)
            {
                Console.WriteLine("Choose your character:");
                Console.WriteLine("W - Warrior");
                Console.WriteLine("M - Mage");
                Console.WriteLine("D - Dragon");
                Console.Write("Enter your choice (W/M/D): ");

                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        Console.Clear();
                        currentCharacter = warrior;
                        Game.DrawImage();
                        break;
                    case ConsoleKey.M:
                        Console.Clear();
                        currentCharacter = mage;
                        Game.DrawImageS();
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        Console.WriteLine(dragonImage);
                        currentCharacter = dragon;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("*******************");

            if (currentCharacter is Dragon || currentCharacter is Warrior || currentCharacter is Mage)
            {
                Console.WriteLine("1. Warrior");
                Console.WriteLine("2. Mage");
                Console.WriteLine("3. Dragon");
                Console.Write("Enter your choice (1/2/3): ");
            
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        currentCharacter.Atack(warrior);
                        break;
                    case ConsoleKey.D2:
                        currentCharacter.Atack(mage);
                        break;
                    case ConsoleKey.D3:
                        currentCharacter.Atack(dragon);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


            if (currentCharacter.Health <= 0)
            {
                Console.WriteLine("You have been defeated!");
                gameEnds = true;
            }
            else if (dragon.Health <= 0)
            {
                Console.WriteLine("You have slain the dragon! Victory!");
                gameEnds = true;
            }
        
        }
    }
}