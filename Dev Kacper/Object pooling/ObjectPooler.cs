using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler<TKey, TComponent> where TComponent : Component
{
    private class Pool
    {
        private readonly TComponent _prefab;
        private readonly Queue<TComponent> _poolQueue;

        public int Count => _poolQueue.Count;

        public Pool(TComponent prefab)
        {
            _prefab = prefab;
            _poolQueue = new Queue<TComponent>();
        }

        public TComponent Dequeue()
        {
            if (Count == 0)
            {
                _poolQueue.Enqueue(Object.Instantiate(_prefab));
            }

            return _poolQueue.Dequeue();
        }

        public void Enqueue(TComponent gameObject)
        {
            _poolQueue.Enqueue(gameObject);
        }
    }

    private readonly Dictionary<TKey, Pool> _poolDictionary = new Dictionary<TKey, Pool>();

    public void AddPool(TKey key, TComponent prefab)
    {
        if (_poolDictionary.ContainsKey(key))
        {
            Debug.LogError("A Pool with such a key already exists!");
            return;
        }

        _poolDictionary.Add(key, new Pool(prefab));
    }

    public TComponent Create(TKey key)
    {
        if (_poolDictionary.TryGetValue(key, out Pool pool))
        {
            var gameObject = pool.Dequeue();
            gameObject.gameObject.SetActive(true);
            return gameObject;
        }

        throw new KeyNotFoundException();
    }

    public void Destroy(TKey key, TComponent gameObject)
    {
        if (!_poolDictionary.ContainsKey(key))
        {
            Debug.LogError("A pool with such a key does not exist!");
            return;
        }

        gameObject.gameObject.SetActive(false);
        _poolDictionary[key].Enqueue(gameObject);
    }
}