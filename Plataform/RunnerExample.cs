// Code by Tales Mariano - TalesMariano.com
// References
// https://www.androidauthority.com/lets-build-a-simple-endless-runner-game-in-unity-759135/
// https://docs.unity3d.com/ScriptReference/Gradient.html
// https://www.youtube.com/watch?v=j111eKN8sJw


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Test Start")]
    public Transform testStart;

    int juum = 0;

    public Stages soStage;

    Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;


    public float speed = 5;
    public float jumpForce = 5;

    public float jumpTime;
    public float jumpTimerCounter;

    public int currentStage = 0;




    // Bools
    private bool onGround = true;
    private bool lastGround = true;
    private bool isJumping = false;
    public bool moving = false;
    bool firstJump = false;


    [Header("Double Jump")]
    public bool doubleJumpleEnabled = false;
    public bool infiniteJumps = false;
    bool doubleJumped;


    TrailRenderer trail;

    [Header("Checkpoint")]
    public Transform lastCheckpoint;

    [Header("Animator")]
    public Animator anim;


    [Header("Audio")]
    public FmodPlayer audioPlayer;

    [Header("Penas")]

    public TrailRenderer[] trailsPenas;
    public ParticleSystem penasParticles;
    public ParticleSystem penasBurst;

    private void Awake()
    {
#if UNITY_EDITOR
        if (testStart != null)
            transform.position = testStart.position;
#endif

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        trail = GetComponentInChildren<TrailRenderer>();
        audioPlayer = GetComponentInChildren<FmodPlayer>();
    }

    // Use this for initialization
    IEnumerator Start()
    {


        StageUpd(currentStage);

        ResetTrais();

        yield return new WaitForSeconds(1.5f);

        firstJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorMove;
        Vector2 vectorJump = Vector2.zero;

        vectorMove = new Vector2(speed, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Land
        if (lastGround == false && onGround == true)
            audioPlayer.Land();

        InputStuff();
    }


    void InputStuff()
    {


        if (Input.GetButtonDown("Jump") && firstJump)
        {
            JumpInput();
            moving = true;
            firstJump = false;
            Debug.Log(" fitrst jump");

        }else if (Input.GetButtonDown("Jump") && moving)
        {
            if (infiniteJumps) //Flying
            {
                FlyInput();
                penasBurst.Play();
            }
            else if (onGround)
            {
                JumpInput();
            }
            else if (doubleJumpleEnabled && !doubleJumped)
            {
                JumpInput();
                doubleJumped = true;
            }


        }
        /*
        if(Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimerCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimerCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        */
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;

            //test stop acending
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 3);
        }

        if (doubleJumped && onGround)
        {
            doubleJumped = false;
        }




        //volume fly
        audioPlayer.goingUp = rb.velocity.y > 0.1f;

        //Animations
        anim.SetBool("OnGround", onGround);

        anim.SetBool("Falling", rb.velocity.y < 0);

        lastGround = onGround;
        //rb.velocity =  vectorJump;
    }


    private void FixedUpdate()
    {
        

        if (moving)
            rb.velocity = new Vector2(speed, rb.velocity.y);

        anim.SetBool("Moving", moving);
    }

    /// <summary>
    /// When take damage, stop moving and play animation.
    /// Later, move to last checkpoint and start moving again
    /// </summary>
    /// <returns></returns>
    void TakeDamage()
    {
        moving = false; // Stop Moving

        foreach (var item in trailsPenas)
        {
            item.enabled = false;
        }


        rb.velocity = new Vector2(0, rb.velocity.y);

        audioPlayer.TakeDamage(); // Play Damage Audio

        anim.SetBool("Damage", true); // Play Damage Anim
        StartCoroutine("ITakeDamage"); // Start Restart Routine
    }

    IEnumerator ITakeDamage()
    {
        yield return new WaitForSeconds(1);
        trail.enabled = false;


        MoveCheckpoint();

        rb.velocity = new Vector2(0, rb.velocity.y); // Stop Movment

        anim.SetBool("Damage", false);

        yield return new WaitForSeconds(2f);
        StartMoving();
    }

    void StartMoving()
    {
        moving = true;
        trail.enabled = true;
        anim.SetBool("Moving", true);

        foreach (var item in trailsPenas)
        {
            item.enabled = true;
        }
    }


    void JumpInput()
    {


        isJumping = true;
        jumpTimerCounter = jumpTime;
        rb.velocity = Vector2.up * jumpForce;
        anim.ResetTrigger("Jump");
        anim.SetTrigger("Jump");


        audioPlayer.Jump(); //Play audio jump


        juum++;

        Debug.Log("jump is " + juum);
    }



    void FlyInput()
    {
        isJumping = true;
        jumpTimerCounter = jumpTime;
        rb.velocity = Vector2.up * jumpForce;
        anim.ResetTrigger("Jump");
        anim.SetTrigger("Jump");


        audioPlayer.Fly(); //Play audio jump
    }

    [ContextMenu("Next Stage")]
    void StageUpd(int numStage)
    {
        StopCoroutine("IStageUP");
        audioPlayer.GrabItem();

        StartCoroutine("IStageUP", numStage);
    }

    IEnumerator IStageUP(int numStage)
    {
        yield return new WaitForSeconds(1.5f); // time to end grab animation

        if (numStage < soStage.stages.Length)
        {  //bug fixer
            speed = soStage.stages[numStage].moveSpeed;
            jumpForce = soStage.stages[numStage].jumpForce;
            jumpTime = soStage.stages[numStage].jumpTime;
        }
        SetTrail(numStage);

        if (numStage > 0)
            ShowTrailPenas(numStage - 1);
    }

    //   
    void NextStage()
    {
        if (currentStage >= soStage.stages.Length - 1)
        {
            ActivateInfiniteJumps();
            currentStage++;
            StageUpd(currentStage);

        }
        else
        {
            currentStage++;
            StageUpd(currentStage);
        }

        if (!doubleJumpleEnabled && currentStage == 4)
        {
            doubleJumpleEnabled = true;
        }
    }

    [ContextMenu("Move Checkpoint")]
    void MoveCheckpoint()
    {
        transform.position = lastCheckpoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Harm")
        {
            TakeDamage();
        }
        else if (collision.tag == "Pickup")
        {
            lastCheckpoint = collision.GetComponent<Pickup>().DropCheckpoint(); //Make checkpoint last pickup; 
            collision.GetComponent<Pickup>().Pickedup(this.transform);
            //lastCheckpoint = collision.transform; 
            NextStage();
        }
        else if (collision.tag == "Checkpoint")
        {
            lastCheckpoint = collision.transform;
        }
        else if (collision.tag == "Endgame")
        {
            GameManager.instance.EndGameScreen();
        }
        else if (collision.tag == "EnterArea")
        {
            GameManager.instance.NextArea();
        }
    }

    [ContextMenu("ActivateInfiniteJumps")]
    void ActivateInfiniteJumps()
    {
        Debug.Log("Start Flying");
        anim.SetBool("Flying", true);

        infiniteJumps = true;
        rb.gravityScale = 0.5f;
        penasParticles.Play();

    }



    // remove form code
    // add to github
    void SetTrail(int numColors)
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        colorKey = new GradientColorKey[numColors];
        alphaKey = new GradientAlphaKey[numColors];

        for (int i = 0; i < numColors; i++)
        {
            colorKey[i].color = soStage.stages[i].color;
            colorKey[i].time = (float)i / (numColors - 0);


            alphaKey[i].alpha = 0.8f;
            alphaKey[i].time = (float)i / (numColors - 0);
        }


        gradient.SetKeys(colorKey, alphaKey);

        trail.colorGradient = gradient;
    }


    void ResetTrais()
    {
        foreach (var item in trailsPenas)
        {
            item.emitting = false;
        }
    }

    void ShowTrailPenas(int num)
    {
        if (num < trailsPenas.Length)
            trailsPenas[num].emitting = true;
    }
}
