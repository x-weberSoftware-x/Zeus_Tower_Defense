using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject[] enemies;

    public GameObject boss = null;
    public float bossSpawnTime = 10;

    public int count;
    public float rate;
}
