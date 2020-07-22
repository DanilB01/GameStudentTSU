 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class PlatfPlayer : MonoBehaviour
{
    //Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);
    public static bool WithKitty = false;
    public RuntimeAnimatorController playerWithKitty;

    // State
    bool isAlive = true;
    bool statWithCat = false;
    //Cached component reference
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeet;
    float gravityScaleAtStart;

    //Score
    public GameObject finalPanel;
    public static int coinsCounter;
    public string lvl;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "success")
        {
            Translator.fromLevel = 7;
        }
        if (SceneManager.GetActiveScene().name == "zero" && !WithKitty)
            coinsCounter = 0;
        if (WithKitty)
        {
            var SpawnPoint = new Vector2(62.72f, 15.38f);
            this.transform.position = SpawnPoint;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = playerRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (WithKitty && !statWithCat)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = playerWithKitty as RuntimeAnimatorController;
            statWithCat = true;
        }
        if (!isAlive) { return; }
        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
        Die();

    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //values -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidBody.velocity.x) > 0.01;
        playerAnimator.SetBool("Running", playerHasHorizontalSpeed);

    }

    private void ClimbLadder()
    {
        if (!playerFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            playerAnimator.SetBool("Climbing", false);
            playerRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(playerRigidBody.velocity.x, controlThrow * climbSpeed);
        playerRigidBody.velocity = climbVelocity;
        playerRigidBody.gravityScale = 0f;

        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidBody.velocity.x) > 0.01;
        playerAnimator.SetBool("Climbing", playerHasHorizontalSpeed);

    }
    private void Jump()
    {
        if (playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                playerRigidBody.velocity = jumpVelocityToAdd;
            }
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        //if player is moving horizontally
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1f);
        }
    }

    private void Die()
    {
        if(playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false; 
            playerAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            PlatfPlayer.WithKitty = false;
            finalPanel.SetActive(true);
            //SceneManager.LoadScene("zero");
        }
    }
}
