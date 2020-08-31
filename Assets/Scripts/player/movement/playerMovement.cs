using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    [Header("Walk/Run Variables")]
    public float walkSpeed;
    public float runSpeed;
    public float currentSpeed;
    public float speedModifier; //will change depending on whether the player is using a speed boosting power
    [Header("Jump Variables")]
    public float jumpForce;
    public ForceMode forceMode;
    public bool jumpPressed;
    public bool grounded;
    public bool canJump = true; //set to false by any actions that prevent the player from jumping, such as attacking. will usually be set outside of the script
    public Transform groundChecker;

    [Header("Crouch Variables")]
    CapsuleCollider collider;
    public float crouchHeight;
    public float normalHeight;
    public bool isCrouching;
    public Transform ceilingChecker;
    public bool canStand; //to see if there is space above the player to uncrouch during periods where they are in a tight space
    public float crouchWalkSpeed; //speed that player moves at when crouching
    public float crouchRunSpeed; //speed that player moves at when crouching + sprinting
    //[Header("Sword animations")]
    //public Animator swordAnim;
    //public bool isMoving = false;
    #endregion

    #region PRIVATE_VARIABLES
    private float xAxis;
    private float zAxis;
    private Rigidbody rigidBody;
    private bool isSprintKeyDown;
    private float groundCheckDistance = 0.1f;
    private float ceilingCheckDistance = 0.5f;
    LayerMask groundMask;
    LayerMask ceilingMask; //will need to be any object that could potentially be above the player
    #endregion
    #region MONOBEHAVIOUR_FUNCTIONS

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
        ceilingMask = LayerMask.GetMask("Ceiling") | groundMask;
        collider = GetComponent<CapsuleCollider>();
        normalHeight = collider.height;
        crouchHeight = collider.height / 2;
    }

    private void Update()
    {
        #region CHECK_GROUNDED
        grounded = Physics.CheckSphere(groundChecker.position, groundCheckDistance, groundMask);
        #endregion
        #region CHECK_CEILING
        canStand = !Physics.CheckSphere(ceilingChecker.position, ceilingCheckDistance, ceilingMask);
        #endregion
        #region GET_INPUTS
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        if ((xAxis != 0 || zAxis != 0) && grounded)
        {
            //isMoving = true;
            //swordAnim.SetBool("isMoving", isMoving);
        }
        else
        {
            //isMoving = false;
            //swordAnim.SetBool("isMoving", isMoving);
        }
        jumpPressed = Input.GetButton("Jump");
        isSprintKeyDown = Input.GetKey(KeyCode.LeftShift);
        #endregion
        #region MODIFY_SPEED
        if(!isCrouching)
        {
            currentSpeed = isSprintKeyDown ? runSpeed : walkSpeed;
        }
        else
        {
            currentSpeed = isSprintKeyDown ? crouchRunSpeed : crouchWalkSpeed;
        }
        currentSpeed = currentSpeed * speedModifier;
        #endregion
       

    }
    private void FixedUpdate()
    {
        #region MOVE_PLAYER
        rigidBody.MovePosition(transform.position + Time.deltaTime * currentSpeed * transform.TransformDirection(xAxis, 0, zAxis));
        #endregion
        #region APPLY_JUMP
        if (jumpPressed && grounded && canJump)
        {
            Jump(jumpForce, forceMode);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && grounded)
        {
            if (isCrouching)
            {
                if(canStand)
                {
                    unCrouch();
                }
            }
            else
            {
                crouch();
            }
            
        }
       
        #endregion
    }
    #endregion
    #region ACTION_FUNCTIONS

    private void Jump(float force, ForceMode mode)
    {
        rigidBody.AddForce(force * rigidBody.mass * Time.deltaTime * Vector3.up, mode);
    }

    private void crouch()
    {
        collider.height = crouchHeight;
        //collider.height = Mathf.MoveTowards(normalHeight, crouchHeight, 0.5f * Time.deltaTime);
        isCrouching = true;
        //groundChecker.transform.position = Vector3.Lerp(groundChecker.transform.position, new Vector3(groundChecker.transform.position.x, groundChecker.transform.position.y + 0.5f, groundChecker.transform.position.z), 1);
        groundChecker.transform.position = new Vector3(groundChecker.transform.position.x, groundChecker.transform.position.y + 0.5f, groundChecker.transform.position.z);

    }
    private void unCrouch()
    {
        collider.height = normalHeight;
        //collider.height = Mathf.MoveTowards(crouchHeight, normalHeight, 1f);
        groundChecker.transform.position = new Vector3(groundChecker.transform.position.x, groundChecker.transform.position.y -0.5f, groundChecker.transform.position.z);
        isCrouching = false;
    }
    #endregion

}



