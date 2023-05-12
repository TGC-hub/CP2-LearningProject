using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movingSpeed;
    public float jumpForce;
    private float moveInput;

    private bool facingRight = false;
   
    public bool deathState = false;

    private bool isGrounded;
    public Transform groundCheck;
   
    private Rigidbody2D rigidbody;
    private Animator animator;

    private GameManager gameManager;

    public bool isNextScenes;


    [SerializeField] private AudioSource soundJump;
    [SerializeField] private AudioSource soundAttack;
    [SerializeField] private AudioSource soundCollect;
    [SerializeField] private AudioSource soundKillenemy;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {

        
        if (Input.GetButton("Horizontal"))
        {
            moveInput = Input.GetAxis("Horizontal");
            Vector3 direction = transform.right * moveInput;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetBool("walkState", true); // Turn on walk animation
            animator.SetBool("jumpState", false);
            animator.SetBool("attackState", false);
           
        }
        else
        {
            animator.SetBool("walkState", false);
            if (isGrounded) { animator.SetBool("jumpState", false); } // Turn on idle animation

        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            soundJump.Play();
            animator.SetBool("attackState", false);
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if (!isGrounded) 
        {
           
            animator.SetBool("jumpState", true); 
            animator.SetBool("walkState", false);
            animator.SetBool("attackState", false);

        }// Turn on jump animation

        if (Input.GetKey(KeyCode.E))
        {
            if (isGrounded)
            {
                if (!soundAttack.isPlaying)
                {
                    soundAttack.Play();
                }
                
                animator.SetBool("attackState", true);
            }

        }
        else
        {
            soundAttack.Stop();
            animator.SetBool("attackState", false);
        }


        if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput < 0)
        {
            Flip();
        }


    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
        isGrounded = colliders.Length > 1;
    }

   

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            deathState = true;
        }
        else
        {
            deathState = false;
        }
        if (collision.gameObject.tag == "CherryPoint")
        {
            soundCollect.Play();
        }

        if(collision.gameObject.tag == "Enemy" && Input.GetKey(KeyCode.E))
        {
            soundKillenemy.Play();
        }

        if(collision.gameObject.tag == "LoadCheckPoints")
        {
           isNextScenes = true;

        }
        else
        {
            isNextScenes = false;
        }

    }


}
