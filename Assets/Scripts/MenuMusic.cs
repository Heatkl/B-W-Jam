using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        SetVolume();
    }
    public void SetVolume()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("volume");
    }
}
