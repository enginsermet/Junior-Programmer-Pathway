using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    GameManager gameManager;

    public float jumpForce = 10.0f;
    public float gravityModifier = 1.0f;
    private bool isOnGround = true;
    private bool isDoubleJump = true;
    public bool boostActive = false;

    public Animator playerAnim;
    [SerializeField]
    private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField]
    private AudioClip jumpAudio, crashAudio;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameManager.gameOver)
        {
            playerAnim.SetTrigger("Jump_trig");
            Jump();
            isOnGround = false;
            isDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !gameManager.gameOver && isDoubleJump)
        {
            playerAnim.Play("Running_Jump", 3, 0f);
            Jump();
            isDoubleJump = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && isOnGround && !gameManager.gameOver)
        {
            boostActive = true;
            Boost();
        }
        else
        {
            boostActive = false;
            playerAnim.speed = 1;
            MoveLeft.speed = 10.0f;          
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Ground") && !gameManager.gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (col.gameObject.tag.Equals("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameManager.gameOver = true;
            audioSource.PlayOneShot(crashAudio, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Stop();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        audioSource.PlayOneShot(jumpAudio, 1.0f);
        dirtParticle.Stop();
    }

    private void Boost()
    {
        MoveLeft.speed = 20;
        playerAnim.speed = 2;
    }
}
