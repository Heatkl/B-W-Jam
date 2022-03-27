using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlLevel : MonoBehaviour
{
    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
    }
    public void AddLevel()
    {
        currentLevel++;
    }
    public int CurrentLevel => currentLevel;
 
}
