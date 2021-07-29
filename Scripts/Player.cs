using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Delecate to BroadCast character state changing to dead.
    public delegate void bcCharcterDeath();
    // The event to declare once player is dead.
    public static event bcCharcterDeath EVDeath;

    public float YAxis;   //How high the player will jump.
    public float XAxis;   //How far the player will jump.
    public float ColliderSize;

    public Rigidbody2D rb;
    private Animator animator;
    public float speed;
    bool jump = false;


    // Different States of the Player
    public enum State
    {
        State_Idle,
        State_Jumping,
        State_Swinging,
        State_Swimming,
    }
    private State currentState =0;
    public State CurrentState
    {
        get
        {
            return currentState;
        }
    }
    private int statePriority = -1;

    // Function for Changing States. Every switch statement is a different state.
    private void ChangeState()
    {
        switch (CurrentState) 
        {
            case State.State_Idle:
                if (CrossPlatformInputManager.GetButtonDown("Jump")) 
                {
                    ManageState(State.State_Jumping);
                    rb.AddForce(new Vector2 (XAxis, YAxis), ForceMode2D.Impulse);
                    jump = true;
                    animator.SetBool("IsJumping",true);
                    this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(ColliderSize, ColliderSize);
                }
                break;

            case State.State_Swinging:
                if (CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    ManageState(State.State_Jumping);
                    Destroy(gameObject.GetComponent(typeof(DistanceJoint2D)));
                    //An impulse is used to move the player
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(XAxis * 1.2f, YAxis * 0.8f), ForceMode2D.Impulse);
                    animator.SetTrigger("IsJumping");
                }
                break;
        }
    }

    // Only allows higher priority state changes to pass in the same frame.
    public void ManageState(Player.State state)
    {
        int priority = (int)state;
        if (statePriority < priority)
        {
            currentState = state;
            statePriority = priority;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
            ManageState(State.State_Idle);
        
     }
    private void Update()
    {
        ChangeState ();
        statePriority = -1;
    }

}
