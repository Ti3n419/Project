using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : TI3NMono
{
    void Update()
    {
        this.MoverObstacle();
    }
    protected virtual void MoverObstacle() 
    {
        transform.parent.position += Vector3.left*GameManager.Instance.GetGameSpeed()*Time.deltaTime;
    }
}
