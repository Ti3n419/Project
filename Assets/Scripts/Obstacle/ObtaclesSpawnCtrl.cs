using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtaclesSpawnCtrl : TI3NMono
{
    [SerializeField] protected ObstaclesSpawner obstaclesSpawner;
    public ObstaclesSpawner ObstaclesSpawner => obstaclesSpawner;

    [SerializeField] protected ObtaclesSpawnPoint obtaclesSpawnPoint;
    public ObtaclesSpawnPoint ObtaclesSpawnPoint => obtaclesSpawnPoint;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstaclesSpawner();
        this.LoadObtaclesSpawnPoint();
        
    }
    protected virtual void LoadObstaclesSpawner()
    {
        if (this.obstaclesSpawner != null) return;
        this.obstaclesSpawner = GetComponent<ObstaclesSpawner>();
        Debug.Log(transform.name + ": LoadObstaclesSpawner", gameObject);

    }
    protected virtual void LoadObtaclesSpawnPoint()
    {
        if (this.obtaclesSpawnPoint != null) return;
        this.obtaclesSpawnPoint = FindObjectOfType<ObtaclesSpawnPoint>();
        Debug.Log(transform.name + ": LoadObtaclesSpawnPoint", gameObject);
    }
  
}
