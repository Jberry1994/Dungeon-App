using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Inventory
    {
        public List<Item> Items { get; set; }

        public Inventory(List<Item> items)
        {
            Items = items;
          //List<Item> items = new List<Item>() { new Item("Placeholder")};
        }

        public override string ToString()
        {
            string items = "";
            foreach (Item item in Items)
            {
                items += item.Name + "\n";
            }
            return items;
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }


}
