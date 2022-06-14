/*
 Player movement and actions for disabling it and enabling it in Play Mode

 Sebasti�n Gonz�lez Villacorta - A01029746
 Karla Valeria Mondrag�n Rosas - A01025108
 Andre�na Isable San�nez Rico - A01024927

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
    private int paralysisTime = 5;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect;
    [SerializeField] private AudioSource paralysisSoundEffect;

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
                jumpSoundEffect.Play();
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }

            if (Input.GetButtonDown("Jump") && isTouchingBox)
            {
                jumpSoundEffect.Play();
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        if (Mathf.Abs(playerAnimation.GetFloat("Speed")) > 0.1f)
        {
            if (!walkSoundEffect.isPlaying)
            {
                walkSoundEffect.Play();

            }

            if (!isTouchingGround)
            {
                walkSoundEffect.Stop();
            }
        }
        else if (Mathf.Abs(playerAnimation.GetFloat("Speed")) < 0.1f)
        {
            walkSoundEffect.Stop();
        }
        playerAnimation.SetBool("OnGround", (isTouchingGround || isTouchingBox));
        playerAnimation.SetBool("PushingBox", isPushingBox);

    }

    private void DisablePlayerMovementPlay()
    {
        playerAnimation.enabled = false;
        player.constraints = RigidbodyConstraints2D.FreezeAll;
        //player.velocity = new Vector2(0f, 0f);
    }

    private void EnablePlayerMovementPlay()
    {
        playerAnimation.enabled = true;
        player.constraints = RigidbodyConstraints2D.None;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        //player.bodyType = RigidbodyType2D.Dynamic;
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
        if (!paralysisSoundEffect.isPlaying)
        {
            paralysisSoundEffect.Play();

        }
        DisablePlayerMovementPlay();
        yield return new WaitForSeconds(paralysisTime);
        paralysis = false;
        EnablePlayerMovementPlay();
    }
}