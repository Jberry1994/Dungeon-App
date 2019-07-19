using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            int diceRoll = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= attacker.CalcHitChance() - defender.CalcBlock())
            {
                // The attacker hit!
                int damageDealt = attacker.CalcDamage();
                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} has dealt {damageDealt} to {defender.Name}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{attacker.Name} missed!");
                Console.ResetColor();
            }


        }
        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }

        }


    }
}
