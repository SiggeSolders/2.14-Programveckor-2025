using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public StamminaControler _stamminaControler;
    [Header("Movement")]
    private float moveSpeed;
    public float walkspeed;
    public float sprintspeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool Grounded;

    [Header("Sound")]
    [SerializeField] AudioSource walkingAudio;
    [SerializeField] AudioSource runningAudio;

    public bool runCooldown = false;

    public Transform orientetion;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        idle,
        air
    }
    void Start()
    {
        _stamminaControler = GetComponent<StamminaControler>();
        rb = GetComponent < Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    public void setRunsSpeed(float speed)
    {
        moveSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        //Ground Check
        Grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f));
        MyInput();
        SpeedControl();
        StateHandler();

        //Drag
        if (Grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void StateHandler()
    {
        if(Grounded && Input.GetKey(sprintKey) && _stamminaControler.playerStammina > 0 && runCooldown == false)
        {
            state = MovementState.sprinting;
            moveSpeed = sprintspeed;

        }else if (Grounded && rb.linearVelocity != Vector3.zero)
        {
            state = MovementState.walking;
            moveSpeed = walkspeed;
        }else if (Grounded)
        {
            state = MovementState.idle;
        }
        else
        {
            state = MovementState.air;
        }
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(state == MovementState.sprinting)
        {
            if(_stamminaControler.playerStammina > 0)
            {
                _stamminaControler.isSprinting = true;
                _stamminaControler.IsSprinting();
            }
        }
        if(state == MovementState.walking)
        {
            _stamminaControler.isSprinting = false;
        }
        //Jump
        if (Input.GetKey(jumpKey) && readyToJump && Grounded)
        {
            _stamminaControler.StamminaJump();
        }
    }

    public void PlayerJump()
    {
        readyToJump = false;

        Jump();

        Invoke(nameof(ResetJump), jumpCooldown);
    }
    private void MovePlayer()
    {
        moveDirection = orientetion.forward * verticalInput + orientetion.right * horizontalInput;

        //On ground
        if (Grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10, ForceMode.Force);

            if (state == MovementState.walking)
            {
                walkingAudio.mute = false;
                runningAudio.mute = true;
            }
            else if (state == MovementState.sprinting)
            {
                walkingAudio.mute = true;
                runningAudio.mute = false;
            }else if (state == MovementState.idle)
            {
                walkingAudio.mute = true;
                runningAudio.mute = true;
            }
        }

        //In Air
        else if (!Grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10 * airMultiplier, ForceMode.Force);
            walkingAudio.mute = true;
            runningAudio.mute = true;
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
    
    private void Jump()
    {
        
        // Kollar Y
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
