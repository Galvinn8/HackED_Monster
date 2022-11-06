using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]  // still keep the variable private, but show them in the terminal
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    // only declare them , hasn't give them a reference yet
    private float movementX;

    private Rigidbody2D myBody;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground"; // use variable more, needs to match up with the Ground tag

    private SpriteRenderer sr;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false; // can only jump once
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  // push the object right up
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //function used to detect collision between game obejct
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))  //check if the object collice with the object with ground tag
        {
            isGrounded = true;  //therefore when the object collide with ground, it can jump again
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    // FixedUpdate is not called every frame like the update function
    void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce; // multiply with time deltaTime to make the movement smooth

    }
    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            // object going to the left side
            anim.SetBool(WALK_ANIMATION, true);  // WALK_ANIMATION is the reference to the Walk parameter int eh transition
            sr.flipX = true;  //flip it under the component SpriteRenderer

        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false  );
        }


    }
}
