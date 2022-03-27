using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private Slider _slider = null;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }
    }
    private void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.value = PlayerPrefs.GetFloat("volume");
    }
    public void UpdateVolume()
    {
        PlayerPrefs.SetFloat("volume", _slider.value);
    }
}
