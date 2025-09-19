using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : TI3NMono
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform lowPos;
    [SerializeField] protected Transform highPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
        this.LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        HidePrefabs();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual Transform Spawn(Transform prefab, Quaternion rotation)
    {
        Vector3 spawnPos = GetSpawnPos(prefab);
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetLocalPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.holder;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public virtual Transform RandomPrefabs()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
    protected virtual Vector3 GetSpawnPos(Transform prefab)
    {    
        ObtaclesCtrl ctrl = prefab.GetComponent<ObtaclesCtrl>();
        if (ctrl.ObtaclesSO != null)
        {
            switch (ctrl.ObtaclesSO.typePos)
            {
                case ObtaclesSO.TypePos.LOW_POS:
                    return this.lowPos.position;
                case ObtaclesSO.TypePos.HIGH_POS:
                    return this.highPos.position;                  
            }
        }
        return this.lowPos.position;
    }
}