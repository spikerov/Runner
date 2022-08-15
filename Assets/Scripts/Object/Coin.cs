using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour 
{
	[SerializeField] private bool rotate;
	[SerializeField] private AudioClip collectSound;
	[SerializeField] private GameObject collectEffect;

    public static UnityAction OnCoin;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
			Collect();
			OnCoin?.Invoke();
		}
    }

	public void Collect()
	{
		if (collectSound)
        {
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		}

		if (collectEffect)
        {
			Instantiate(collectEffect, transform.position, Quaternion.identity);
        }

		gameObject.SetActive(false);
	}
}
