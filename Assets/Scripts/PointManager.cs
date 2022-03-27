using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private int _points = 0;

    [SerializeField] private TMP_Text _multiplierText;
    [SerializeField] private int _multiplier = 1;
    [SerializeField] private float _maxFontSize = 200f;
    [SerializeField] private float _minFontSize = 100f;
    [SerializeField] private float _step = 10f;

    [SerializeField] private int _snowballCost = 1;
    [SerializeField] private PointsSaver _pointSaver = null;

    public int Points
    {
        get
        {
            return _points;
        }
        set
        {
            _points = value;

            _pointSaver.scores = _points;
            UpdateUI();
        }
    }
    private void Start()
    {
        _points = 0;
        _pointText.text = "0";
    }
    private void Update()
    {
        UpdateUI();
    }
    public void AddPoints()
    {
        Points = _points + _snowballCost * _multiplier;
        _multiplier += 1;
    }
    private void UpdateUI()
    {
        _pointText.text = $"{_points}";
        _multiplierText.text = $"x{_multiplier}";

        _multiplierText.fontSize = _minFontSize + _multiplier * _step;

        if(_multiplierText.fontSize > _maxFontSize)
        {
            _multiplierText.fontSize = _maxFontSize;
        }
    }
    public void Miss()
    {
        _multiplier = 1;
    }
}
