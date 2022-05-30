//Player movement and actions for diabling and enabling it

// Sebastián González Villacorta
// A01029746
// Karla Valeria Mondragón Rosas
// A01025108

// 13/05/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePlay : MonoBehaviour
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

    private bool paralysis;
    private int paralysisTime = 3;

    private void OnEnable()
    {
        CountdownPlay.OnTimerRunOutPlay += DisablePlayerMovementPlay;
        LevelGoalPlay.GoalReachedPlay += DisablePlayerMovementPlay;
    }

    private void OnDisable()
    {
        CountdownPlay.OnTimerRunOutPlay -= DisablePlayerMovementPlay;
        LevelGoalPlay.GoalReachedPlay -= DisablePlayerMovementPlay;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        EnablePlayerMovementPlay();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isTouchingBox = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, boxesLayer);
        direction = Input.GetAxis("Horizontal");


        if (paralysis)
        {
            StartCoroutine(WaitForParalysis());
        }
        else
        {
            if (direction > 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
                transform.localScale = new Vector2(2f, 2f);
            }
            else if (direction < 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
                transform.localScale = new Vector2(-2f, 2f);
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
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", (isTouchingGround || isTouchingBox));

    }

    private void DisablePlayerMovementPlay()
    {
        playerAnimation.enabled = false;
        player.velocity = new Vector2(0f, 0f);
    }

    private void EnablePlayerMovementPlay()
    {
        playerAnimation.enabled = true;
        player.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Imer"))
        {
            paralysis = true;
        }
    }

    IEnumerator WaitForParalysis()
    {
        DisablePlayerMovementPlay();
        yield return new WaitForSeconds(paralysisTime);
        paralysis = false;
        EnablePlayerMovementPlay();
    }
}