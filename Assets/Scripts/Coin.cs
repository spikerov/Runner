using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour 
{
	[SerializeField] private bool rotate;
	[SerializeField] private float rotationSpeed;
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

    void Update () {

		if (rotate)
        {
			transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
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
