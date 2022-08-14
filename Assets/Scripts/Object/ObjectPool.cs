using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _localities = new List<GameObject>();
    private List<GameObject> _inactiveLocality = new List<GameObject>();

    private int _minCountInactive = 2;

    protected void Initialize(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.SetActive(false);
        _localities.Add(spawned);
        _inactiveLocality.Add(spawned);
    }

    protected bool TryGetObject(out GameObject result)
    {
        if (_inactiveLocality.Count < _minCountInactive)
        {
            foreach (var locality in _localities)
            {
                if (locality.activeSelf == false)
                {
                    _inactiveLocality.Add(locality);
                }
            }
        }

        result = _inactiveLocality[Random.Range(0, _inactiveLocality.Count - 1)];
        _inactiveLocality.Remove(result);

        return result != null;
    }
}
