//Player movement and actions for diabling and enabling it

// Sebastián González Villacorta
// A01029746
// Karla Valeria Mondragón Rosas
// A01025108

// 13/05/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public LayerMask boxesLayer;
    private bool isTouchingGround;
    private bool isTouchingBox;

    private Animator playerAnimation;

    private void OnEnable()
    {
        Countdown.OnTimerRunOut += DisablePlayerMovement;
        LevelGoal.GoalReached += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        Countdown.OnTimerRunOut -= DisablePlayerMovement;
        LevelGoal.GoalReached -= DisablePlayerMovement;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        EnablePlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isTouchingBox = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, boxesLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction*speed, player.velocity.y);
            transform.localScale = new Vector2(1.903704f, 1.903704f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-1.903704f, 1.903704f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if (Input.GetButtonDown("Jump") && isTouchingBox)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", (isTouchingGround || isTouchingBox));
 
    }

    private void DisablePlayerMovement()
    {
        playerAnimation.enabled = false;
        player.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement()
    {
        playerAnimation.enabled = true;
        player.bodyType = RigidbodyType2D.Dynamic;
    }
}
