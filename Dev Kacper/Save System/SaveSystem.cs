using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.SaveSystem
{
    public class SaveSystem
    {
        private List<ISaveable> _saveables = new List<ISaveable>();

        public void AddSaveable(ISaveable saveable)
        {
            saveable.Save();

            _saveables.Add(saveable);
        }

        public void FindAllSaveables()
        {
            GameObject[] allGameObjects = Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < allGameObjects.Length; ++i)
            {
                if (allGameObjects[i].TryGetComponent(out ISaveable saveable))
                {
                    if (!_saveables.Contains(saveable))
                    {
                        _saveables.Add(saveable);
                    }
                }
            }
        }

        public void SaveAllData()
        {
            for (int i = 0; i < _saveables.Count; ++i)
            {
                _saveables[i].Save();
            }
        }

        public void LoadAllData()
        {
            for (int i = 0; i < _saveables.Count; ++i)
            {
                _saveables[i].Load();
            }
        }
    }
}