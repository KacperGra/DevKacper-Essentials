using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace DevKacper.Utility
{
    public static class UtilityClass
    {
        public const int sortingOrderDefault = 5000;
        public static Camera _mainCamera = null;

        public static float GetAngleFromVector(Vector3 direction)
        {
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle < 0)
            {
                angle += 360f;
            }

            return angle;
        }

        public static Vector3 WorldPositionToGrid(Vector3 worldPosition, float cellSize = 1f)
        {
            int x = Mathf.FloorToInt(worldPosition.x * cellSize);
            int y = Mathf.FloorToInt(worldPosition.y * cellSize);
            int z = Mathf.FloorToInt(worldPosition.z * cellSize);
            return new Vector3(x, y, z);
        }

        public static Vector2 GetRandomDirection(float range = 1f)
        {
            return UnityEngine.Random.insideUnitCircle.normalized * range;
        }

        public static Vector2 GetMousePosition()
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }

            return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        public static Vector2 GetGridMousePosition()
        {
            Vector2 mousePosition = GetMousePosition();
            mousePosition = new Vector2(Mathf.FloorToInt(mousePosition.x), Mathf.FloorToInt(mousePosition.y));
            return mousePosition + Vector2.one * 0.5f;
        }

        public static Vector2 GetMousePositionInRadius(Vector2 position, float radius)
        {
            var mousePosition = GetMousePosition();

            var direction = mousePosition - position;
            direction = Vector2.ClampMagnitude(direction, radius);

            return direction;
        }

        public static Vector2 GetAbsoluteVector2(Vector2 vector)
        {
            return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        public static Vector3 GetAbsoluteVector3(Vector3 vector)
        {
            return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        }

        public static string GetTextFromFile(string path)
        {
            return File.ReadAllText(Application.dataPath + path);
        }

        public static T StringToEnum<T>(string text) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), text);
        }

        public static T GetStringToEnum<T>(string text) where T : Enum
        {
            foreach (T type in Enum.GetValues(typeof(T)))
            {
                if (type.Equals(StringToEnum<T>(text)))
                {
                    return type;
                }
            }
            return (T)Enum.Parse(typeof(T), text);
        }

        public static int RandomRange(int minimum, int maximum)
        {
            UnityEngine.Random.InitState(UnityEngine.Random.Range(0, 256666));
            return UnityEngine.Random.Range(minimum, maximum);
        }

        public static void ToggleVisibility(GameObject toggleObject)
        {
            toggleObject.SetActive(!toggleObject.activeSelf);
        }

        public static List<T> GetShuffledList<T>(List<T> list)
        {
            var array = list;

            for (int i = 0; i < list.Count; i++)
            {
                int rand = UnityEngine.Random.Range(0, list.Count);
                (array[i], array[rand]) = (array[rand], array[i]);
            }

            return array;
        }

        public static string GetStringWithColor(string text, string hexColorValue)
        {
            return $"<color={hexColorValue}>{text}</color>";
        }

        public static Vector3 RandomPointInBounds(Bounds bounds)
        {
            return new Vector3(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
                UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        // Create Text in the World
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default, int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
        {
            if (color == null) color = Color.white;
            return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }

        // Create Text in the World
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }

        public static Vector2 GetVector2Center(Vector2 first, Vector2 second)
        {
            return (first + second) / 2f;
        }

        public static Vector2 GetVector2Center(Transform[] array)
        {
            float totalX = 0;
            float totalY = 0;
            foreach (Transform transform in array)
            {
                totalX += transform.position.x;
                totalY += transform.position.y;
            }
            return new Vector2(totalX, totalY) / (array.Length + 1);
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        public static T[] LoadJsonData<T>(string resourcesPath)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(resourcesPath);
            string json = textAsset.text;
            return FromJson<T>(json);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}