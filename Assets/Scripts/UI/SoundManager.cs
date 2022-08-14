using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _changeTrack;
    [SerializeField] private AudioSource _collision;
    [SerializeField] private AudioSource _lose;

    public void PlayChangeTrack()
    {
        _changeTrack.Play();
    }
    public void PlayCollision()
    {
        _collision.Play();
    }
    public void PlayLose()
    {
        _lose.Play();
    }

    public void StopBackroundSound()
    {
        _audioSource.Stop();
    }
}
