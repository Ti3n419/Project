using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtaclesCtrl : TI3NMono
{
    [SerializeField] protected ObtaclesSO obtaclesSO;
    public ObtaclesSO ObtaclesSO => obtaclesSO;

    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected ObstaclesDepawn ostaclesDepawn;
    public ObstaclesDepawn ObstaclesDepawn => ostaclesDepawn;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadObstaclesDepawn();
        this.LoadAnimator();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }
    protected virtual void LoadObstaclesDepawn() 
    {
        if (this.ostaclesDepawn != null) return;
        this.ostaclesDepawn = GetComponentInChildren<ObstaclesDepawn>();
    }
    protected virtual void LoadAnimator() 
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
    }
}
