using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _prefab = null;
    [SerializeField] private GameObject _firstInstance = null;
    [SerializeField] private GameObject _secondInstance = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private Transform _spawnTrigger = null;

    private void Start()
    {
        _firstInstance = Instantiate(_prefab, _spawnTrigger.position, Quaternion.identity, gameObject.transform);
        _secondInstance = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, gameObject.transform);
    }
    void Update()
    {
        _firstInstance.transform.position -= new Vector3(0f, Time.deltaTime * _speed, 0f);
        _secondInstance.transform.position -= new Vector3(0f, Time.deltaTime * _speed, 0f);

        if(_secondInstance.transform.position.y <= _spawnTrigger.position.y)
        {
            _firstInstance.transform.position = _spawnTrigger.transform.position;
            _secondInstance.transform.position = _spawnPoint.transform.position;
        }
    }
}