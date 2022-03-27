using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class YetiController : MonoBehaviour
{
    [SerializeField] private KeyCode _keyToPress = KeyCode.A;

    private Animator _animator;

    [SerializeField] private PointManager _pointManager = null;

    [SerializeField] private List<Snowball> _currentSnowball = null;

    private SpriteRenderer _sprite = null;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyToPress))
        {
            PressKey();
        }
    }
    private void PressKey()
    {
        _animator.SetTrigger("hit");

        if(_currentSnowball.Count == 0)
        {
            MissSnowball();
            return;
        }

        foreach(Snowball snowball in _currentSnowball)
        {
            snowball.SmashSnowball();
            _pointManager.AddPoints();
        }
    }

    public void MissSnowball()
    {
        _pointManager.Miss();

        StartCoroutine(MissSnowballCoroutine());
    }

    private IEnumerator MissSnowballCoroutine()
    {
        for(float i = 1; i >= 0.5f; i = i - 0.05f)
        {
            _sprite.color = new Color(1, 1, 1, i);

            yield return new WaitForSeconds(0.05f);
        }
        for (float i = 0.5f; i <= 1; i = i + 0.05f)
        {
            _sprite.color = new Color(1, 1, 1, i);

            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentSnowball.Add(collision.gameObject.GetComponent<Snowball>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _currentSnowball.Remove(collision.gameObject.GetComponent<Snowball>());
    }
}
