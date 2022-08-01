using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKacper.Timers;

public class TimerTesting : MonoBehaviour
{
    [SerializeField] private int _timerCount = 5;
    [SerializeField] private float _minTime = 1f;
    [SerializeField] private float _maxTime = 2f;

    [SerializeField] private GameObject _circlePrefab;
    [SerializeField] private float _maxCirclePosRange = 5f;

    private List<GameObject> _circles = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _timerCount; ++i)
        {
            var circle = Instantiate(_circlePrefab);
            circle.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();

            TimerBehaviour timer = TimerBehaviour.Create(UnityEngine.Random.Range(_minTime, _maxTime), () =>
            {
                circle.transform.position = UnityEngine.Random.insideUnitCircle * _maxCirclePosRange;
            });
            timer.ResetOnFinish = true;
        }
    }
}