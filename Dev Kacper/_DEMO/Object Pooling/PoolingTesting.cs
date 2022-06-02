using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testing.Pooling
{
    public class PoolingTesting : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _circlePrefab;

        private List<SpriteRenderer> _circleList;
        private ObjectPooler<string, SpriteRenderer> _pooler;

        private void Start()
        {
            _circleList = new List<SpriteRenderer>();
            _pooler = new ObjectPooler<string, SpriteRenderer>();
            _pooler.AddPool("Circle", _circlePrefab);
        }

        private void Update()
        {
            for (int i = 0; i < 25; ++i)
            {
                float randomValue = UnityEngine.Random.value;
                if (randomValue < 0.5f)
                {
                    var circle = _pooler.Create("Circle");

                    Vector2 randomPos = UnityEngine.Random.insideUnitCircle;
                    circle.transform.position = new Vector2(randomPos.x * 8f, randomPos.y * 4f);
                    circle.color = UnityEngine.Random.ColorHSV();

                    _circleList.Add(circle);
                }
                else
                {
                    if (_circleList.Count == 0)
                    {
                        return;
                    }

                    _pooler.Destroy("Circle", _circleList[0]);
                    _circleList.RemoveAt(0);
                }
            }
        }
    }
}