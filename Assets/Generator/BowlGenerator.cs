
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BowlGenerator : MonoBehaviour
{
    private BowlLevel bl;
    const int EASY_GAME_LEVELS = 10;
    const float STEP_BETWEEN_BOWLS = 4.0f;
    GameObject[,] bowls = new GameObject[6,10];
    [SerializeField] private Vector3 coordsOfFirstBall = new Vector3(-8.0f, 20f ,0);
    [SerializeField] private GameObject _prefab = null;
    //[SerializeField] private Transform _spawnPoint = null;
    //[SerializeField] private Transform _spawnTrigger = null;

    void Start()
    {
        bl = gameObject.GetComponent(typeof(BowlLevel)) as BowlLevel;
        for(int i = 0; i < 6; i++)
        {
            Vector3 currentCoordinates = new Vector3(coordsOfFirstBall.x+i*STEP_BETWEEN_BOWLS, coordsOfFirstBall.y, coordsOfFirstBall.z);
            for(int j = 0; j < 10; j++)
            {
                currentCoordinates = new Vector3(currentCoordinates.x, currentCoordinates.y+STEP_BETWEEN_BOWLS, currentCoordinates.z);
                bowls[i, j]= Instantiate(_prefab, currentCoordinates + gameObject.transform.position, Quaternion.identity, gameObject.transform);
                bowls[i, j].SetActive(false);
            }
        }
        SetModeForScroller();
    }

    void Update()
    {
        //SetModeForScroller();
    }

    void BackLadder()
    {
        //Обратная лестница
        for (int i = 0; i < 6; i++)
        {
            bowls[5-i, i].SetActive(true);
            bowls[5-i, i + 4].SetActive(true);
        }
    }
    
    void Ladder()
    {
        //Лестница
        for (int i = 0; i < 6; i++)
        {
            bowls[i, i].SetActive(true);
            bowls[i, i+4].SetActive(true);
        }
    }

    void Chess()
    {
        //Шахматы
        for ( int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                bowls[i, j*2+i%2].SetActive(true);
            }

        } 
    }

    public void RandomGeneration(int _level, bool isStartOfGame)
    {

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                bowls[i, j].SetActive(false);
            }
        }

        if (isStartOfGame)
        {

            for (int i = 0; i < 10; i++)
            {
                int bowlsQuantity = Random.Range(1, 1 + _level / 5);
                //int[] nonexceptionPosition = { 0, 1, 2, 3, 4, 5 };
                List<int> nonexceptionPositions = new List<int>() { 0, 1, 2, 3, 4, 5 };
          
                for (int j = 0; j < bowlsQuantity; j++)
                {
                    int bowlPosition = RandomFromRangeWithExceptions(nonexceptionPositions);          
                    bowls[bowlPosition, i].SetActive(true);
                    nonexceptionPositions.Remove(bowlPosition);
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                int bowlsQuantity = Random.Range(1, 2);
                //int[] nonexceptionPosition = { 0, 1, 2, 3, 4, 5 };
                List<int> nonexceptionPositions = new List<int>() { 0, 1, 2, 3, 4, 5 };

                for (int j = 0; j < bowlsQuantity; j++)
                {
                    int bowlPosition = RandomFromRangeWithExceptions(nonexceptionPositions);
                    bowls[bowlPosition, i].SetActive(true);
                    nonexceptionPositions.Remove(bowlPosition);
                }
            }
        }
    }


    public void SetModeForScroller()
    {
        int currentLevel = bl.CurrentLevel;
        bool isStartOfGame = currentLevel < EASY_GAME_LEVELS;
        if (isStartOfGame)
        {
            int selectRandomMode = Random.Range(0, currentLevel % 5);
            switch (selectRandomMode)
            {
                case 2:
                    Ladder();
                    break;
                case 3:
                    BackLadder();
                    break;
                case 4:
                    Chess();
                    break;
                default:
                    RandomGeneration(currentLevel, isStartOfGame);
                    break;

            }
        }else RandomGeneration(currentLevel, isStartOfGame);

    }

    private int RandomFromRangeWithExceptions(List<int> _include)
    {
        int index = Random.Range(0, _include.Count);
        return _include[index];
    }
}

