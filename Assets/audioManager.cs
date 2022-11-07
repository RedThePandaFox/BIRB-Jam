using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource source;
    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
