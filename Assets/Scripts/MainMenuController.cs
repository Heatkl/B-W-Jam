using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _main = null;
    [SerializeField] private GameObject _settings = null;
    [SerializeField] private GameObject _about = null;

    private List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        list.Add(_main);
        list.Add(_settings);
        list.Add(_about);

        OpenMain();
    }
    public void OpenMain()
    {
        foreach(GameObject go in list)
        {
            go.SetActive(false);
        }
        _main.SetActive(true);
    }
    public void OpenSettings()
    {
        foreach (GameObject go in list)
        {
            go.SetActive(false);
        }
        _settings.SetActive(true);
    }
    public void OpenAbout()
    {
        foreach (GameObject go in list)
        {
            go.SetActive(false);
        }
        _about.SetActive(true);
    }
}
