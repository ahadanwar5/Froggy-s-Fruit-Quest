 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;
    private float directionX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState {idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(directionX * moveSpeed, player.velocity.y);
  
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        updateAnimationState();
    }

    private void updateAnimationState()
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (player.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (player.velocity.y < -0.1f)
        {
            state = MovementState.falling; 
        }
    
        anim.SetInteger("state", (int)state); 
    }

    private bool isGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
