using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace WeaponLibrary
{
    public class Dagger : Weapon
    {
        public bool IsPoisoned { get; set; }
        public int PoisonStrength { get; set; }
        public Dagger(string name, int bonusHitChance, int minDamage, int maxDamage, bool isPoisoned, int poisonStrength)
            : base(name, bonusHitChance, minDamage, maxDamage)
        {
            IsPoisoned = isPoisoned;
            PoisonStrength = poisonStrength;
        }
        public Dagger(string name, int bonusHitChance, int minDamage, int maxDamage, bool isPoisoned)
            : base(name, bonusHitChance, minDamage, maxDamage)
        {
            IsPoisoned = isPoisoned;
        }
        public override int CalcMinDamage()
        {
            return IsPoisoned ? MinDamage + PoisonStrength : base.CalcMinDamage();
        }
        public override int CalcMaxDamage()
        {
            return IsPoisoned ? MaxDamage + PoisonStrength : base.CalcMaxDamage();
        }
    }
}
