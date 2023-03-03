using DevKacper.SaveSystem;
using System.Collections;
using UnityEngine;

namespace Testing.SaveSystem
{
    public class TestingSaveObject : MonoBehaviour, ISaveable
    {
        private TestingSaveData _dataToSave;

        public void Load()
        {
            _dataToSave = (TestingSaveData)SerializationManager.Load($"{name}.save");
            Debug.Log($"{name}: Loaded {_dataToSave}");
        }

        public void Save()
        {
            _dataToSave = new TestingSaveData(Random.onUnitSphere, UnityEngine.Random.Range(0, 100), Random.ColorHSV().ToString());
            SerializationManager.Save(name, _dataToSave);
            Debug.Log($"{name}: Saved {_dataToSave}");
        }
    }

    [System.Serializable]
    public class TestingSaveData
    {
        private Vector3 _vectorToSave;
        private int _intToSave;
        private string _stringToSave;

        public Vector3 VectorToSave => _vectorToSave;
        public int IntToSave => _intToSave;
        public string StringToSave => _stringToSave;

        public TestingSaveData(Vector3 vector, int intValue, string stringValue)
        {
            _vectorToSave = vector;
            _intToSave = intValue;
            _stringToSave = stringValue;
        }

        public override string ToString()
        {
            return $"Vector:{_vectorToSave}| Int:{_intToSave}| String:{_stringToSave}";
        }
    }
}