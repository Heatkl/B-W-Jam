using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    [SerializeField] private YetiController _yeti;

    private void Start()
    {
        _yeti = GetComponentInParent<YetiController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Snowball")
        {
            _yeti.MissSnowball();
        }
    }
}
