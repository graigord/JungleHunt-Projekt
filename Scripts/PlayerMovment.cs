using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController2D controller;
    public Animator animator;
    //public Collider water;

    public float runSpeed = 40f;
    public float moving = 0f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalMove = (CrossPlatformInputManager.GetAxis("Horizontal")) * runSpeed - moving;
        verticalMove = CrossPlatformInputManager.GetAxis("Vertical") * runSpeed;
        /*horizontalMove = (Input.GetAxisRaw("Horizontal")) * runSpeed - moving;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;*/

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove) + moving);

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (CrossPlatformInputManager.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (CrossPlatformInputManager.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }



    void FixedUpdate()
    {
        controller.Move((horizontalMove) * Time.fixedDeltaTime, crouch, jump, (verticalMove) * Time.fixedDeltaTime);
        jump = false;
    }
}

