using DevKacper.SaveSystem;
using System.Collections;
using UnityEngine;

namespace Testing.SaveSystem
{
    public class TestingSaveObject : MonoBehaviour, ISaveable
    {
        private int _dataToSave;

        public void Load()
        {
            _dataToSave = (int)SerializationManager.Load($"{name}.save");
            Debug.Log($"{name}: Loaded {_dataToSave}");
        }

        public void Save()
        {
            _dataToSave = UnityEngine.Random.Range(0, 100);
            SerializationManager.Save(name, _dataToSave);
            Debug.Log($"{name}: Saved {_dataToSave}");
        }
    }
}