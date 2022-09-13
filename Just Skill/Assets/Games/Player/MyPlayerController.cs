using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    [Header("Movements")]
    public float moveSpeed;

    [Header("Jump")]
    public float jumpForce;
    private bool readyToJump = true;
    public float jumpCooldown;
    public float airSpeed;

    [Header("Ground Checking")]
    public float playerHeight;
    public LayerMask isGroundMask;
    public bool grounded;
    public float groundDrag;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //tcheck ground
        grounded = Physics.Raycast(this.transform.position, Vector3.down, playerHeight / 2 + 0.05f, isGroundMask) | Physics.Raycast(new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Vector3.down, playerHeight / 2 + 0.05f, isGroundMask) | Physics.Raycast(new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z), Vector3.down, playerHeight / 2 + 0.05f, isGroundMask);
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+0.2f,transform.position.y,transform.position.z), Vector3.down, Color.green);


        MyInput();
        SpeedControle();
        //print(rb.velocity.magnitude);
        //apply drag
        if (grounded)
        {
            rb.drag = groundDrag;   
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void PlayerMovement()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed *10f, ForceMode.Force);
        }
        else
        {
            //add speed if necessary
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airSpeed, ForceMode.Force);

        }
    }
    private void SpeedControle()
    {
        if(rb.velocity.magnitude > moveSpeed)
        {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
