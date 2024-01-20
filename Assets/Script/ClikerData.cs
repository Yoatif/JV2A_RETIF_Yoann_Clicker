using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hunter", menuName = "NoIdea", order = 0)]
public class ClikerData : ScriptableObject
{
    public float ClickHunterScore1 = 0;
    public int HunterHealth;
    public int HunterType;
    public Sprite[] HunterPic;
}
