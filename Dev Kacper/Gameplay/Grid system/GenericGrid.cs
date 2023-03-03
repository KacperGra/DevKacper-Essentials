using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevKacper.Gameplay
{
    public class GenericGrid<T>
    {
        public class OnGridObjectChangedEventArgs : EventArgs
        {
            public int x;
            public int y;
        }

        public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;

        private readonly int _width;
        private readonly int _height;
        private readonly float _cellSize;
        private Vector3 _originPosition;

        private readonly T[,] _gridArray;

        public GenericGrid(int width, int height, float cellSize, Vector3 originPosition, Func<GenericGrid<T>, int, int, T> createGridObject)
        {
            this._width = width;
            this._height = height;
            this._cellSize = cellSize;
            this._originPosition = originPosition;

            _gridArray = new T[width, height];

            for (int x = 0; x < _gridArray.GetLength(0); ++x)
            {
                for (int y = 0; y < _gridArray.GetLength(1); ++y)
                {
                    _gridArray[x, y] = createGridObject(this, x, y);
                }
            }
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public float GetCellSize()
        {
            return _cellSize;
        }

        public Vector3 GetOrigin()
        {
            return _originPosition;
        }

        private Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, y) * _cellSize + _originPosition;
        }

        public void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPosition - _originPosition).x / _cellSize);
            y = Mathf.FloorToInt((worldPosition - _originPosition).y / _cellSize);
        }

        public void SetObject(int x, int y, T value)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                _gridArray[x, y] = value;
                TriggerGridObjectChanged(x, y);
            }
        }

        public void TriggerGridObjectChanged(int x, int y)
        {
            OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, y = y });
        }

        public void SetObject(Vector3 worldPosition, T value)
        {
            GetXY(worldPosition, out int x, out int y);
            SetObject(x, y, value);
        }

        public T GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                return _gridArray[x, y];
            }
            return default;
        }

        public T GetValue(Vector3 worldPosition)
        {
            GetXY(worldPosition, out int x, out int y);
            return GetValue(x, y);
        }
    }
}