using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.Mechanic
{
    public abstract class Item
    {
        protected int id;
        public int ID => id;

        protected string name;
        public string Name => name;
    }
}
