using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    public float jumpForce = 10.0f;
    public float gravityModifier = 1.0f;
    private bool isOnGround = true;
    private bool gameOver = false;

    private Animator playerAnim;
    [SerializeField]
    private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField]
    private AudioClip jumpAudio, crashAudio;

    public bool GameOver
    {
        get
        {
            return gameOver;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpAudio, 1.0f);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (col.gameObject.tag.Equals("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;
            audioSource.PlayOneShot(crashAudio, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Stop();
        }
    }
}
