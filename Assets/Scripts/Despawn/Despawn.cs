using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : TI3NMono
{
    protected void FixedUpdate() 
    {
        this.Despawning();
    }
    protected virtual void Despawning() 
    {
        if(!this.CanDespawn()) return;
        this.DespawnObj();
    }
    public virtual void DespawnObj()
    {

    }
    protected abstract bool CanDespawn();
}
