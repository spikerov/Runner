using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityAction OnEndLocation;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<LocalityEnable>(out LocalityEnable locality))
        {
            OnEndLocation?.Invoke();
        }
    }
}
