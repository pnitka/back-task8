using System;

// Практика A
public abstract class Creature
{
    public string Name { get; set; }
    public int Health { get; set; }

    public abstract void Attack(Creature target);

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }
    }
}

// Практика B
public class Hero : Creature
{
    public int AttackPower { get; set; }

    public Hero(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public override void Attack(Creature target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage!");
        target.TakeDamage(AttackPower);
    }
}

public class Monster : Creature
{
    public int AttackPower { get; set; }

    public Monster(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public override void Attack(Creature target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage!");
        target.TakeDamage(AttackPower);
    }
}

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual void Use(Hero hero)
    {
        Console.WriteLine($"Using {Name}: {Description}");
    }
}

// Практика C
public class HealingPotion : Item
{
    private int healingAmount;

    public HealingPotion(string name, string description, int healingAmount)
    {
        Name = name;
        Description = description;
        this.healingAmount = healingAmount;
    }

    public override void Use(Hero hero)
    {
        Console.WriteLine($"Using {Name}: {Description}");
        hero.Health += healingAmount;
        Console.WriteLine($"{hero.Name} healed for {healingAmount}. Current health: {hero.Health}");
    }
}

public class Game
{
    private Hero hero;
    private Monster monster;

    public Game(Hero hero, Monster monster)
    {
        this.hero = hero;
        this.monster = monster;
    }

    public void Play()
    {
        Console.WriteLine("Game started!");
        while (hero.Health > 0 && monster.Health > 0)
        {
            hero.Attack(monster);
            if (monster.Health > 0)
            {
                monster.Attack(hero);
            }
            Console.WriteLine($"{hero.Name} health: {hero.Health}");
            Console.WriteLine($"{monster.Name} health: {monster.Health}");
        }

        if (hero.Health > 0)
        {
            Console.WriteLine($"{hero.Name} wins!");
        }
        else
        {
            Console.WriteLine($"{monster.Name} wins!");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Hero hero = new Hero("Arthur", 100, 20);
        Monster monster = new Monster("Goblin", 80, 15);

        Game game = new Game(hero, monster);
        game.Play();

        HealingPotion potion = new HealingPotion("Minor Healing Potion", "Restores a small amount of health", 30);
        potion.Use(hero);
    }
}
