using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testing.SaveSystem
{
    public class SaveSystemTesting : MonoBehaviour
    {
        private DevKacper.SaveSystem.SaveSystem _saveSystem;

        private void Start()
        {
            _saveSystem = new DevKacper.SaveSystem.SaveSystem();
            _saveSystem.FindAllSaveables();

            _saveSystem.SaveAllData();
            _saveSystem.LoadAllData();
        }
    }
}