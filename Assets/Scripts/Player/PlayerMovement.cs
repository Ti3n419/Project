using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : TI3NMono
{
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private PlayerCtrl playerCtrl;
    private bool isGrounded;
    private bool isDuck;
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

        HandleJump();
        HandleDuck();
        HandleSoundEffect();

    }
    private bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && !isDuck)
        {
            this.PlayerCtrl.Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void HandleDuck()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
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
