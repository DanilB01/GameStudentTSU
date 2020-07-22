using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForse;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigitbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Animator myAnimator;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    public GameObject finalPanel;
    public GameObject pauseMenu;
    PauseMenu pause;

    void Start()
    {
        PlayerPrefs.SetFloat("HighScore", 0);

        myRigitbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;

        pause = pauseMenu.GetComponent<PauseMenu>();
    }

    void Update()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone + speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigitbody.velocity = new Vector2(moveSpeed, myRigitbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                myRigitbody.velocity = new Vector2(myRigitbody.velocity.x, jumpForse);
                stoppedJumping = false;
                jumpSound.Play();
            }

            if(!grounded && canDoubleJump)
            {
                myRigitbody.velocity = new Vector2(myRigitbody.velocity.x, jumpForse);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
                jumpSound.Play();
            }
        }

        if((Input.GetKey(KeyCode.Space)) && !stoppedJumping)
        {
            if(jumpTimeCounter > 0)
            {
                myRigitbody.velocity = new Vector2(myRigitbody.velocity.x, jumpForse);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRigitbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();
            pause.enabled = false;
            finalPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
