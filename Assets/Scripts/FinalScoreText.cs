using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScoreText : MonoBehaviour
{
    [SerializeField] private float _durationSeconds = 10f;
    [SerializeField] private PointsSaver _points = null;
    [SerializeField] private TMP_Text _text = null;

    // Start is called before the first frame update
    void Start()
    {
        _durationSeconds = _durationSeconds / _points.scores;
        _text.text = "0";

        StartCoroutine(ScrollDigit());
    }

    private IEnumerator ScrollDigit()
    {
        for(int i = 0; i <= _points.scores; i += 5)
        {
            i = i > _points.scores ? _points.scores : i;
            _text.text = i.ToString();

            yield return new WaitForSeconds(_durationSeconds);
        }
    }
}
