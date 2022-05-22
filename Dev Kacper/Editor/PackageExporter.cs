using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DevKacper.Editor
{
    public class PackageExporter : UnityEditor.Editor
    {
        [MenuItem("Tools/DevKacper/Package/Export")]
        public static void Export()
        {
            string[] foldersToSearch = new[] { "Assets/Scripts/DevKacper-Essentials", "Assets/DevKacper-Essentials" };
            string[] guids = AssetDatabase.FindAssets("", foldersToSearch);

            string[] assetArray = new string[guids.Length];
            for (int i = 0; i < guids.Length; ++i)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                assetArray[i] = path;
            }

            AssetDatabase.ExportPackage(assetArray, "Essentials.unitypackage", ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);
        }
    }
}