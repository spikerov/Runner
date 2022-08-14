using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : SpawnedOdjects
{
    [SerializeField] private GameObject[] _objectForSpawn;
    [SerializeField] private int _countObjectSpawned;
    [SerializeField] private int _minDistanceBetwenObject;
    [SerializeField] private int _maxDistanceBetwenObject;

    private List<GameObject> _activeObject = new List<GameObject>();
    private int _zDistanceBetweenObject;
    private int number = 0;
    private int _startSpawnCountLocality = 30;
    private float _spawnPositionZ = 5;
    private float _spawnPositionX = 5;
    private List<float> _xPositionSpawnObject = new List<float> { -0.8f, 0f, 0.8f };

    private void OnEnable()
    {
        Coin.OnCoin += ActivateObject;
        Coin.OnCoin += DeactivateObject;
    }

    private void OnDisable()
    {
        Coin.OnCoin -= ActivateObject;
        Coin.OnCoin -= DeactivateObject;
    }

    private void Start()
    {
        for (int i = 0; i < _objectForSpawn.Length; i++)
        {
            Initialize(_objectForSpawn[i]);
        }

        for (int i = 0; i < _startSpawnCountLocality; i++)
        {
            ActivateObject();
        }
    }

    public void ActivateObject()
    {
        if (TryGetObject(out GameObject locality))
        {
            Debug.Log("object" + number++);
            _zDistanceBetweenObject = Random.Range(_minDistanceBetwenObject, _maxDistanceBetwenObject);
            _spawnPositionX = _xPositionSpawnObject[Random.Range(0, _xPositionSpawnObject.Count)];
            locality.SetActive(true);
            locality.transform.position = new Vector3(_spawnPositionX, 0, _spawnPositionZ);
            _spawnPositionZ += _zDistanceBetweenObject;
            _activeObject.Add(locality);
        }
    }

    private void DeactivateObject()
    {
        _activeObject[0].SetActive(false);
        _activeObject.RemoveAt(0);
    }

    public void DeleteDisactivateObjectFromList()
    {
        for (int i = 0; i < _activeObject.Count; i++)
        {
            if (_activeObject[i].activeSelf == false)
            {
                _activeObject.RemoveAt(i);
                ActivateObject();
            }
        }
    }
}