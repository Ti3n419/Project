using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDepawn : DespawnByDis
{
    public override void DespawnObj()
    {
        ObstaclesSpawner.Instance.Despawn(transform.parent);
    }
}
