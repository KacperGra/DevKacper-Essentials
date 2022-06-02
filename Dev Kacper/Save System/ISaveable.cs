using System.Collections;
using UnityEngine;

namespace DevKacper.SaveSystem
{
    public interface ISaveable
    {
        public void Save();

        public void Load();
    }
}