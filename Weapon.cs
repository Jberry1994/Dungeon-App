using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon : Item
    {
        // fields
        private int _minDamage;

        // properties
        // Properties with business rules always go last because the business rules may rely on the value
        // of other properties.
        public bool IsTwoHanded { get; set; }
        public int BonusHitChance { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage { get { return _minDamage; } set { _minDamage = value > 0 && value <= MaxDamage ? value : 1; } }


        // ctors

        public Weapon(string name, bool isTwoHanded, int bonusHitChance, int minDamage, int maxDamage)
            : base(name)
        {
            // MinDamage has a dependency on MaxDamage, so MaxDamage MUST be set before MinDamage.
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
        public Weapon(string name, int bonusHitChance, int minDamage, int maxDamage)
            : base(name)
        {
            BonusHitChance = bonusHitChance;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
        // methods
        public override string ToString()
        {
            // MINI-LAB!
            // Build a ternary operator to display if the weapon is two-handed or not
            return base.ToString() + string.Format($"\n{MinDamage} to {MaxDamage} damage\nBonus Hit: {BonusHitChance}%\n" +
                $"{(IsTwoHanded ? "Two-handed" : "One-handed")}");
        }
        public virtual int CalcMinDamage()
        {
            return MinDamage;
        }
        public virtual int CalcMaxDamage()
        {
            return MaxDamage;
        }

    }
}
