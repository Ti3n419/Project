using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    RUN, JUMP, FALL
}
public class PlayerCtrl : TI3NMono
{
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private BoxCollider2D boxCollider2d;
    [SerializeField] private CapsuleCollider2D capsuleCollider2d;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private State state = State.RUN;
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
    protected virtual void Update()
    {
        Debug.Log((int)this.state);
        Vector3 velocity = this.rigidbody2d.velocity;
        switch (this.state)
        {
            case State.RUN:
                if (velocity.y > 0) this.state = State.JUMP;
                break;
            case State.JUMP:
                if (velocity.y < 0) this.state = State.FALL;
                break;
            case State.FALL:
                if (velocity.y == 0) this.state = State.RUN;
                break;
        }
        this.animator.SetInteger("State", (int)this.state);
    }
}
