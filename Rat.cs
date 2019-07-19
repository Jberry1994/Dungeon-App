using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Rat : Monster
    {


        public bool IsFilthy { get; set; }

        public Rat(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description, bool isFilthy)
            : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {
            IsFilthy = isFilthy;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n{(IsFilthy ? "The horror! The smell is so bad you can hardly move!" : "")}";
        }

        public override int CalcBlock()
        {
            return IsFilthy ? Block + (Block / 2) : Block;
        }


    }
}
