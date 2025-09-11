using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtaclesSpawnerRandom : TI3NMono
{
    [SerializeField] protected ObtaclesSpawnCtrl obtaclesSpawnCtrl;
    public ObtaclesSpawnCtrl ObtaclesSpawnCtrl => obtaclesSpawnCtrl;

    [SerializeField] protected float randomDelay = 2f;
    [SerializeField] protected float randomTimer = 0f;

    protected override void LoadComponents() 
    {
        this.LoadObtaclesSpawnCtrl();
    }
    protected virtual void LoadObtaclesSpawnCtrl() 
    {
        if(this.obtaclesSpawnCtrl != null) return;
        this.obtaclesSpawnCtrl = GetComponent<ObtaclesSpawnCtrl>();
        
    }
    protected virtual void FixedUpdate() 
    {

        this.ObtaclesSpawning();
    }
    protected virtual void ObtaclesSpawning() 
    {
        this.randomTimer += Time.fixedDeltaTime;
        if(this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;
        //Transform randPoint = this.obtaclesSpawnCtrl.ObtaclesSpawnPoint.GetRandom();
        //Vector3 pos = randPoint.position;
        Quaternion rot = Quaternion.identity;
        Transform prefab = this.obtaclesSpawnCtrl.ObstaclesSpawner.RandomPrefabs();
        Transform obj = this.obtaclesSpawnCtrl.ObstaclesSpawner.Spawn(prefab, rot);
        obj.gameObject.SetActive(true);
    }
}
