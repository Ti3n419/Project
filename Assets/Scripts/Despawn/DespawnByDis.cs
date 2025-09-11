using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDis : Despawn
{
    [SerializeField] protected float leftBoundary = -10f;
    protected override bool CanDespawn()
    {
        if(transform.position.x< leftBoundary) return true;
        return false;
    }
}
