using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Wolf : Monster
    {
        public bool Pack { get; set; }
        public Wolf(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description, bool pack)
            : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {
            Pack = pack;

        }
        public override string ToString()
        {
            return base.ToString() + $"\n{(Pack ? "More wolfs join the fight!" : "")}";
        }
        public override int CalcHitChance()
        {
            return Pack ? HitChance + (HitChance / 2) : HitChance;
        }

    }
}
