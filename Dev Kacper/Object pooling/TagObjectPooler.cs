using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.ObjectPooler
{
    public class TagObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            [Header("General")]
            [SerializeField] private string tag;
            [SerializeField] private GameObject prefab;
            [SerializeField] private int size;

            public string Tag => tag;
            public GameObject Prefab => prefab;
            public int Size => size;
        }

        public List<Pool> poolList;
        public static Dictionary<string, Queue<GameObject>> poolQueue;

        public static TagObjectPooler Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            poolQueue = new Dictionary<string, Queue<GameObject>>();

            foreach(Pool pool in poolList)
            {
                var newQueue = new Queue<GameObject>();
                var poolParent = new GameObject($"{pool.Tag}Content");

                for(int i = 0; i < pool.Size; ++i)
                {
                    var newPrefabObject = Instantiate(pool.Prefab, poolParent.transform);
                    newPrefabObject.SetActive(false);
                    newQueue.Enqueue(newPrefabObject);
                }

                poolQueue.Add(pool.Tag, newQueue);
            }
        }

        public static GameObject Spawn(string tag)
        {
            var spawnedObject = poolQueue[tag].Dequeue();
            spawnedObject.SetActive(true);
            poolQueue[tag].Enqueue(spawnedObject);
            return spawnedObject;
        }

        public static GameObject Spawn(string tag, Vector3 position)
        {
            var spawnedObject = Spawn(tag);
            spawnedObject.transform.position = position;
            return spawnedObject;
        }

        public static GameObject Spawn(string tag, Vector3 position, Quaternion rotation)
        {
            var spawnedObject = Spawn(tag, position);
            spawnedObject.transform.position = position;
            return spawnedObject;
        }

        public static GameObject Spawn(string tag, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var spawnedObject = Spawn(tag, position, rotation);
            spawnedObject.transform.localScale = scale;
            return spawnedObject;
        }
    }
}
