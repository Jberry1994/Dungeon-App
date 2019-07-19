using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Spider : Monster
    {
        public bool InWeb { get; set; }
        public Spider(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description, bool inWeb)
            : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {
            InWeb = inWeb;
        }
        public override string ToString()
        {
            return base.ToString() + $"\n{(InWeb ? "You've walked into the spiders web, you can hardly move!" : "")}";
        }

        public override int CalcBlock()
        {
            return InWeb ? Block + (Block / 2) : Block;
        }



    }
}
