using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDisactivator : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Coin>(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _objectSpawner.DeleteDisactivateObjectFromList();
        }
        else if (collider.TryGetComponent<Rock>(out Rock rock))
        {
            rock.gameObject.SetActive(false);
            _objectSpawner.DeleteDisactivateObjectFromList();
        }
    }
}
