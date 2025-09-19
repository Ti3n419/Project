using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : PoolSpawner
{
    private static ObstaclesSpawner instance;
    public static ObstaclesSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ObstaclesSpawner.instance != null) Debug.Log("Only once Ins pls!");
        ObstaclesSpawner.instance = this;
    }

}
