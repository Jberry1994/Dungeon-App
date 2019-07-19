using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        // Automatic properties are a shortcut syntax that was introduced with .Net 3.5 that allows
        // us to quickly make a property that doesnt have a business rule. Auto properties automatically 
        // create a related field at runtime and therefor do not require us to manually write a field.


        // Fields

        // Properties

        public Weapon EquippedWeapon { get; set; }
        public PlayerRace Race { get; set; }
        public int Potions { get; set; }
        public int InventorySize { get; set; }
        public Inventory PlayerInventory { get; set; }
        public int MonstersSlain { get; set; }
        // Ctors
        public Player(string name, int hitChance, int block, int life, int maxLife, Weapon equippedWeapon, PlayerRace race, Inventory playerInventory)
        {

            Maxlife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = equippedWeapon;
            Race = race;
            Potions = 0; // start with 0 potions
            InventorySize = 5;
            PlayerInventory = playerInventory;
            MonstersSlain = 0;
            //PlayerInventory.Items.Capacity = InventorySize;
            switch (Race)
            {
                case PlayerRace.Human:
                    Potions += 1;
                    HitChance += 5;
                    Block += 5;
                    break;
                case PlayerRace.Elf:
                    break;
                case PlayerRace.Dwarf:
                    Maxlife += 10;
                    Life += 10;
                    break;
                case PlayerRace.Orc:
                    break;
                case PlayerRace.Gnome:
                    break;
                case PlayerRace.DragonBorn:
                    break;
                case PlayerRace.Halfling:
                    break;
                case PlayerRace.HalfElf:
                    break;
                case PlayerRace.HalfOrc:
                    break;
                case PlayerRace.Tiefling:
                    break;
                default:
                    break;
            }


        }
        public Player(string name, int hitChance, int block, int life, int maxLife)
        {
            Maxlife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = new Weapon("test",0,0,1);
            Race = PlayerRace.Human;
            Potions = 0; // start with 0 potions
            InventorySize = 5;
            PlayerInventory = new Inventory(new List<Item>());
            MonstersSlain = 0;
        }
        // Methods
        public override string ToString()
        {
            string description = "";
            switch (Race)
            {
                case PlayerRace.Human:
                    description = "You're a human.";
                    break;
                case PlayerRace.Elf:
                    description = "You're an elf.";
                    break;
                case PlayerRace.Dwarf:
                    description = "You're a dwarf.";
                    break;
                case PlayerRace.Orc:
                    description = "You're an orc.";
                    break;
                case PlayerRace.Gnome:
                    description = "You're a gnome.";
                    break;
                case PlayerRace.DragonBorn:
                    description = "You're a dragonborn";
                    break;
                case PlayerRace.Halfling:
                    description = "You're a halfling.";
                    break;
                case PlayerRace.HalfElf:
                    description = "You're a half-elf.";
                    break;
                case PlayerRace.HalfOrc:
                    description = "You're a half-orc.";
                    break;
                case PlayerRace.Tiefling:
                    description = "You're a tiefling.";
                    break;
            }

            return string.Format($"-=-= {Name} =-=-\nLife: {Life}/{Maxlife}\nHit Chance: {HitChance}%\n" +
                $"Weapon:\n{EquippedWeapon}\nBlock: {Block}\nPotions: {Potions}\nDesciption: {description}\n");
        }

        
        public override int CalcBlock()
        {
            return EquippedWeapon.IsTwoHanded ? Block / 2 : Block;
        }

        // MINI-LAB!
        // Make the CalcHitChance() return HitChance. Make it overridable:
        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.CalcMinDamage(), EquippedWeapon.CalcMaxDamage() + 1);
        }
        public override int CalcHealing()
        {
            return 1;
        }
        public void UsePotion()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Potions > 0)
            {
                if (Life < Maxlife)
                {
                    
                    Console.WriteLine($"You drink a potion.\nYou're now at full health!");
                    Life = Maxlife;
                    Potions--;
                }
                else
                {
                    Console.WriteLine("Already full health!");
                }
            }
            else
            {
                Console.WriteLine("You are out of potions!");
            }
            Console.ResetColor();
        }

        public Inventory ShowInventory()
        {
            return PlayerInventory;
        }
        public static Player LoadGame()
        {
            string docPath = "C: \\Users\\Student\\Documents\\Visual Studio 2015\\Projects\\DungeonApplicatonPersonal\\DungeonApplication\\SaveLoad.txt";
            string input = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(docPath))
                {
                    // Read the stream to a string, and write the string to the console.
                    input += sr.ReadToEnd();

                    Console.WriteLine(input);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            string[] temp = input.Split('-');
            string name = temp[0];
            int hitChance = int.Parse(temp[1]);
            int block = int.Parse(temp[2]);
            int life = int.Parse(temp[3]);
            int maxLife = int.Parse(temp[4]);
            int monstersSlain = int.Parse(temp[5]);
            return new Player(name, hitChance, block, life, maxLife);
        }


    }
}
