using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoURLPlayer : MonoBehaviour
{
    void Start()
    {
        GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "yeti.mp4");
        GetComponent<VideoPlayer>().Play();
    }
}
