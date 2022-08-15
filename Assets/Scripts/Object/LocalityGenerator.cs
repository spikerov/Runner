using System.Collections.Generic;
using UnityEngine;

public class LocalityGenerator : ObjectPool
{
    [SerializeField] private GameObject[] _tamplateLocalities;

    private List<GameObject> _activeLocality = new List<GameObject>();
    private float _spawnPositionZ = 0;
    private float _localityLength = 96;
    private int _startSpawnCountLocality = 3;

    private void OnEnable()
    {
        Player.OnEndLocation += ActivateLocality;
        Player.OnEndLocation += DeactivateLocality;
    }

    private void OnDisable()
    {
        Player.OnEndLocation -= ActivateLocality;
        Player.OnEndLocation -= DeactivateLocality;
    }

    private void Start()
    {
        for (int i = 0; i < _tamplateLocalities.Length; i++)
        {
            Initialize(_tamplateLocalities[i]);
        }

        for (int i = 0; i < _startSpawnCountLocality; i++)
        {
            ActivateLocality();
        }
    }

    public void ActivateLocality()
    {
        if (TryGetObject(out GameObject locality))
        {
            locality.SetActive(true);
            locality.transform.position = new Vector3(0, 0, _spawnPositionZ);
            _spawnPositionZ += _localityLength;
            _activeLocality.Add(locality);
        }
    }

    private void DeactivateLocality()
    {
        _activeLocality[0].SetActive(false);
        _activeLocality.RemoveAt(0);
    }
}
