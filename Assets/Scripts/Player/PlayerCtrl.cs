using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : TI3NMono
{
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private BoxCollider2D boxCollider2d;
    [SerializeField] private CapsuleCollider2D capsuleCollider2d;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public Rigidbody2D Rigidbody2D => rigidbody2d;
    public BoxCollider2D BoxCollider2D => boxCollider2d;
    public CapsuleCollider2D CapsuleCollider2D => capsuleCollider2d;
    public Animator Animator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
        this.LoadBoxCollider2D();
        this.LoadCapsuleCollider2D();
        this.LoadAnimator();
        this.LoadSpriteRenderer();
    }
    protected virtual void LoadRigidbody2D()
    {
        if (rigidbody2d != null) return;
        this.rigidbody2d = this.GetComponentInChildren<Rigidbody2D>();
    }
    protected virtual void LoadBoxCollider2D()
    {
        if (boxCollider2d != null) return;
        this.boxCollider2d = this.GetComponentInChildren<BoxCollider2D>();
    }
    protected virtual void LoadCapsuleCollider2D()
    {
        if (capsuleCollider2d != null) return;
        this.capsuleCollider2d = this.GetComponentInChildren<CapsuleCollider2D>();
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        this.animator = this.GetComponentInChildren<Animator>();
    }
    protected virtual void LoadSpriteRenderer()
    {
        if (spriteRenderer != null) return;
        this.spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
    }

}
