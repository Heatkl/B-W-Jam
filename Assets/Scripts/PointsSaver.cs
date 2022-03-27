using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Points", menuName ="Points", order = 51)]
public class PointsSaver : ScriptableObject
{
    public int scores = 0;
    public int highscore = 0;
}
