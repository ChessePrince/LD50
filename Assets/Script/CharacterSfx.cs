using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSfx : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip shootClip;
    public AudioClip hurtClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurtClip, Random.Range(0.4f, 0.6f));
    }
    public void PlayShoot(float min, float max)
    {
        audioSource.PlayOneShot(shootClip, Random.Range(min, max));
    }
}
