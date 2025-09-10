using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SpawnPoint : TI3NMono
{
    [SerializeField] protected List<Transform> points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform point in transform)
        {
            points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }
    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, points.Count);
        return this.points[rand];
    }
}
