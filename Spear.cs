using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace WeaponLibrary
{
    public class Spear : Weapon
    {


        public Spear(string name, int bonusHitChance, int minDamage, int maxDamage) 
            : base(name, bonusHitChance, minDamage, maxDamage)
        {
            IsTwoHanded = true;
        }
    }
}
