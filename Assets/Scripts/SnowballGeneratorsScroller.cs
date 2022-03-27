using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballGeneratorsScroller : MonoBehaviour
{
    [SerializeField] private GameObject _firstInstance = null;
    [SerializeField] private GameObject _secondInstance = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private Transform _spawnTrigger = null;

    void Update()
    {
        if (_secondInstance.transform.position.y <= _spawnTrigger.position.y)
        {
            _secondInstance.transform.position = _spawnPoint.transform.position;
            _secondInstance.GetComponent<BowlLevel>().AddLevel();
            _secondInstance.GetComponent<BowlGenerator>().SetModeForScroller();
        }
        else if(_firstInstance.transform.position.y <= _spawnTrigger.position.y)
        {
            _firstInstance.transform.position = _spawnPoint.transform.position;
            _firstInstance.GetComponent<BowlLevel>().AddLevel();
            _firstInstance.GetComponent<BowlGenerator>().SetModeForScroller();
        }
    }
}
