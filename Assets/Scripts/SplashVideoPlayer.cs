using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class SplashVideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<VideoPlayer>();
        _player.url = System.IO.Path.Combine(Application.streamingAssetsPath, "yeti.mp4");

        _player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.isPlaying)
        {
            SceneLoader.LoadNextScene();
        }
    }
}
