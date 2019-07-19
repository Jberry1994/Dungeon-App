using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;
        private int _maxDamage;

        public string Description { get; set; }
        public int MaxDamage { get { return _maxDamage; } set { _maxDamage = value; } }
        public int MinDamage { get { return _minDamage; } set { _minDamage = value > 0 && value <= MaxDamage ? value : 1; } }

        // MINI-LAB! Build an FQCTOR
        public Monster(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description)
        {
            Maxlife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            Description = description;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }

        public override string ToString()
        {
            return string.Format($"{Name}\nLife: {Life}/{Maxlife}\nDamage: {MinDamage} - {MaxDamage}\n" +
                $"Hit Chance: {CalcHitChance()}%\nBlock: {CalcBlock()}\nDescription:\n{Description}");
        }

        public override int CalcBlock()
        {
            return Block;
        }

        public override int CalcHitChance()
        {
            return HitChance;
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }


    }
}
