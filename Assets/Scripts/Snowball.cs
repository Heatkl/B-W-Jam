using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
public class Snowball : MonoBehaviour
{
    [SerializeField] private int _startScalePoint = 16;
    [SerializeField] private int _endScalePoint = 0;
    [SerializeField] private Animator _animator = null;

    private Transform _transform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        _transform.localScale = SnowballScale(_transform.position.y);
    }

    private Vector3 SnowballScale(float y)
    {
        if (y > _startScalePoint) { return _transform.localScale; }

        if(y <= _startScalePoint && y >= _endScalePoint)
        {
            return new Vector3(-y/32+1, -y/32+1, 1);
        }

        return Vector3.one;
    }

    public void SmashSnowball()
    {
        _animator.SetTrigger("smash");
    }
    public void DestroySnowball()
    {
        gameObject.SetActive(false);
    }
}
