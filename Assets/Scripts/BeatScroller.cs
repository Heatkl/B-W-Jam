using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField] private float _beatTempo = 0f;
    [SerializeField] private float _speed = 4f;
    
    private bool _hasStarted = false;

    public bool HasStarted
    {
        set { _hasStarted = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _beatTempo = _beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted) { return; }

        transform.position -= new Vector3(0f, _beatTempo * Time.deltaTime * _speed, 0f);
    }
}
