using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader = null;
    void Start()
    {
        SceneLoader.PauseGame();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneLoader.ResumeGame();
            Destroy(this.gameObject);
        }
    }
}
