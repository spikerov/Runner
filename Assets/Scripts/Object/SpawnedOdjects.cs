using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedOdjects : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _container;

    private List<GameObject> _objects = new List<GameObject>();
    private List<GameObject> _inactiveObjects = new List<GameObject>();

    private int _minCountInactive = 10;

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _objects.Add(spawned);
            _inactiveObjects.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        if (_inactiveObjects.Count < _minCountInactive)
        {
            foreach (var locality in _objects)
            {
                if (locality.activeSelf == false)
                {
                    _inactiveObjects.Add(locality);
                }
            }
        }

        result = _inactiveObjects[Random.Range(0, _inactiveObjects.Count - 1)];
        _inactiveObjects.Remove(result);

        return result != null;
    }


}
