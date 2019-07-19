using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return string.Format($"{Name}");
        }

       

    }
}
