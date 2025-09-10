using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 15f;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private Animator anim;
    [SerializeField] private BoxCollider2D normalCollider;
    [SerializeField] private CapsuleCollider2D duckCollider;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        normalCollider.enabled = true;
        duckCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void HandleDuck()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            normalCollider.enabled = false;
            duckCollider.enabled = true;
            anim.SetBool("isDuck", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            normalCollider.enabled = true;
            duckCollider.enabled = false;
            anim.SetBool("isDuck", false);
        }
    }
    private void HandleSoundEffect()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
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
    //protected virtual void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Obstacle"))
    //    {
    //        AudioManager.instance.PlayHurtClip();
    //        //Debug.Log("blyat");
    //    }
    //}
}