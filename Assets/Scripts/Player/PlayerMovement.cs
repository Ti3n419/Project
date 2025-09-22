using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    RUN,
    JUMP,
    FALL
}

public class PlayerMovement : TI3NMono
{
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private State state = State.RUN;
    private bool isGrounded;
    private bool isDuck;
    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
    }
    protected virtual void Start()
    {
        this.PlayerCtrl.BoxCollider2D.enabled = true;
        this.PlayerCtrl.CapsuleCollider2D.enabled = false;
    }
    protected virtual void Update()
    {
        if (GameManager.Instance.IsGameOver) return;// khi game over khong the thao tac
        this.isGrounded = this.CheckIfGrounded();
        this.HandleJump();
        this.HandleDuck();
        this.UpdateAnim();
        this.HandleSoundEffect();
    }
    private bool CheckIfGrounded()
    {
        Vector2 dir = new Vector2(0, -90);
        return Physics2D.Raycast(transform.position, dir, 0.5f, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Vector2 dir = new Vector2(0, -90);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, dir.normalized * 0.5f);
    }
    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded && !isDuck)
        {
            this.PlayerCtrl.Rigidbody2D.velocity = new Vector2(this.playerCtrl.Rigidbody2D.velocity.x, this.jumpForce);
        }
    }
    private void HandleDuck()
    {
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            this.PlayerCtrl.BoxCollider2D.enabled = false;
            this.PlayerCtrl.CapsuleCollider2D.enabled = true;
            this.PlayerCtrl.Animator.SetBool("isDuck", true);
            this.isDuck = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && isGrounded)
        {
            this.PlayerCtrl.BoxCollider2D.enabled = true;
            this.PlayerCtrl.CapsuleCollider2D.enabled = false;
            this.PlayerCtrl.Animator.SetBool("isDuck", false);
            this.isDuck = false;
        }
    }
    protected virtual void UpdateAnim()
    {
        //Debug.Log((int)this.state);
        Vector3 velocity = this.PlayerCtrl.Rigidbody2D.velocity;
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
        this.PlayerCtrl.Animator.SetInteger("State", (int)this.state);
    }
    private void HandleSoundEffect()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && !isDuck)
        {
            AudioManager.Instance.PlayJumpClip();
        }
        if (isGrounded && !AudioManager.Instance.HasPlayEffectSound())
        {
            AudioManager.Instance.PlayTapClip();
            AudioManager.Instance.SetHasPlayEffectSound(true);
        }
        else if (!isGrounded)
        {
            AudioManager.Instance.SetHasPlayEffectSound(false);

        }
    }
}
