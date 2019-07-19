using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        // The abstract keyword indicates that the thing being modified is an incomplete implementation.
        // It indicates that the class is intended to only be a parentto pass class members to child classes
        // and that it cannot be instantiated

        // Fields
        private int _life;

        // Properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int Maxlife { get; set; }
        public int Life { get { return _life; } set { _life = value <= Maxlife ? value : Maxlife; } }

        // We dont inherit ctors from the parent and because Character is abstract
        // we are never going to instantiate one. Therefore, we won't build a ctor here.
        // Instead, we'll get the free, parameterless one, but we'll never be able to use it.

        public virtual int CalcBlock()
        {
            return Block;
        }

        // MINI-LAB!
        // Make the CalcHitChance() return HitChance. Make it overridable:
        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
        public virtual int CalcHealing()
        {
            return 0;
        }

    }
}
