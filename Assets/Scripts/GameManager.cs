using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicPlayer;
    [SerializeField] private BeatScroller _beatScroller;
    [SerializeField] private BeatScroller _secondBeatScroller;
    [SerializeField] private TMP_Text _text;

    private bool _hasStarted = false;
    void Update()
    {
        if (!_hasStarted)
        {
            if (Input.anyKeyDown)
            {
                _text.gameObject.SetActive(false);
                _hasStarted = true;
                _beatScroller.HasStarted = true;
                _secondBeatScroller.HasStarted = true;
                StartCoroutine(StartLevelCoroutine());
            }
        }
    }
    private IEnumerator StartLevelCoroutine()
    {
        _musicPlayer.Play();

        yield return new WaitForSeconds(_musicPlayer.clip.length);

        SceneLoader.LoadNextScene();
    }
}
