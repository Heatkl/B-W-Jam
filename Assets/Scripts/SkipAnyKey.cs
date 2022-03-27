using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipAnyKey : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneLoader.LoadNextScene();
        }
    }
}
