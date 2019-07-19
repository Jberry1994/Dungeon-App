using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public enum PlayerRace
    {
        // There is no direct way to create an enum through the vs interface.
        // To make one, first create a class, make it public, then change the class keyword to enum.
        Human,
        Elf,
        Dwarf,
        Orc,
        Gnome,
        DragonBorn,
        Halfling,
        HalfElf,
        HalfOrc,
        Tiefling
    }
}
