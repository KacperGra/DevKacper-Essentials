using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.Mechanic
{
    public class Inventory
    {
        protected Dictionary<int, Slot> slots;

        public Inventory(int size)
        {
            slots = new Dictionary<int, Slot>();
            for(int i = 0; i < size; ++i)
            {
                slots.Add(i, new Slot());
            }
        }

        public void SetSize(int size)
        {
            slots = new Dictionary<int, Slot>();
            for (int i = 0; i < size; ++i)
            {
                slots.Add(i, new Slot());
            }
        }

        public Item GetItem(int id)
        {
            if(slots.ContainsKey(id))
            {
                return slots[id].item;
            }
            return null;
        }

        public void SetItem(Item item, int id)
        {
            slots[id].item = item;
        }

        public void RemoveItem(Item item)
        {
            if(item == null)
            {
                return;
            }

            foreach(Slot slot in slots.Values)
            {
                if(slot.item == item)
                {
                    slot.item = null;
                    return;
                }
            }
        }

        public void AddItem(Item item)
        {
            if(item == null)
            {
                return;
            }

            foreach(Slot slot in slots.Values)
            {
                if(slot.item == null)
                {
                    slot.item = item;
                    return;
                }
            }
        }

        public void AddItems(List<Item> items)
        {
            if(items == null)
            {
                return;
            }

            foreach(Item item in items)
            {
                AddItem(item);
            }
        }

        public void Swap(int firstItemID, int secondItemID)
        {
            Item firstItem = GetItem(firstItemID);
            Item secondItem = GetItem(secondItemID);

            slots[firstItemID].item = secondItem;
            slots[secondItemID].item = firstItem;
        }
    }
}


