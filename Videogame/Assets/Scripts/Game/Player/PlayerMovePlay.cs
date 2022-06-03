/*
 Player movement and actions for disabling it and enabling it in Play Mode

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 23/05/2022
 
 */

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

    public Transform boxCheck;
    public float boxCheckRadius;
    private bool isPushingBox;

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

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        EnablePlayerMovementPlay();
    }

    void Update()
    {
        //Check if touching ground or box for jumping mechanics
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isTouchingBox = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, boxesLayer);
        isPushingBox = Physics2D.OverlapCircle(boxCheck.position, boxCheckRadius, boxesLayer);
        direction = Input.GetAxis("Horizontal");


        //Restrict movement after touching Imer
        if (paralysis)
        {
            //Couroutine to wait set amount of seconds
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
        playerAnimation.SetBool("PushingBox", isPushingBox);

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