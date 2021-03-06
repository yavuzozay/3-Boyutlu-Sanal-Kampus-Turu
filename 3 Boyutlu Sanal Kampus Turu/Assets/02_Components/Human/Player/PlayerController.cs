using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    //Animation&state
   private Animator PlayerAnimator;
    private float AnimationBlendSpeed = 2f;

    private bool isIdle;
    private bool isOnGround;
    private bool isWalking;
    private bool isSprinting;
    private float desiredAnimSpeed;

    private bool canMove = true;

    //Input
    private float h_input;
    private float v_input;
    private float mouseX;
    private float speedY=0;
    private float plGravity = -9.81f;

    [Range(1.2f, 2.5f)] [SerializeField] float speedFactor=1.5f;
    
    [SerializeField] float rotationSpeed;

    private Vector3 kampusStartPos;
    private Vector3 lakeStartPos;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        PlayerAnimator = GetComponent<Animator>();
        kampusStartPos = new Vector3(382, 0.5f, 26);
        lakeStartPos = new Vector3(75, 15, 20);
    }
    private void Start()
    {
        isIdle = true;
        isOnGround = characterController.isGrounded;
    }
    private void Update()
    {
     
        CheckMovement();
        CheckInput();
        CheckAnimation();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {

            ApplyMovement();
            ApplyRotation();
        }
    }
    void CheckAnimation()

    {
        PlayerAnimator.SetBool("isIdle", isIdle);
        PlayerAnimator.SetBool("isWalking", isWalking);
        PlayerAnimator.SetBool("isOnGround", isOnGround);
        PlayerAnimator.SetFloat("Speed",Mathf.Lerp(PlayerAnimator.GetFloat("Speed"),desiredAnimSpeed,AnimationBlendSpeed*Time.deltaTime));
    }
 
    void CheckMovement()
    {
        isOnGround = characterController.isGrounded;
        if (PlayerData.Instance.forwardSpeed > .01f&&isOnGround)
        {
            isWalking = true;
            isIdle = false;
            desiredAnimSpeed = isSprinting ? 1 : 0;
        }
        else
        {
            if (isOnGround)
            {
                isIdle = true;
                desiredAnimSpeed = 0;

            }
            isWalking = false;
        }
    }
    void CheckInput()
    {
        if (GameState.Instance.curState != States.Player)
        {
            canMove = false;
           PlayerData.Instance.forwardSpeed=0;

            return;

        }
        canMove = true;
        // h_input = Input.GetAxisRaw("Horizontal");
        v_input = Input.GetAxis("Vertical");
        if (v_input < 0)
            v_input = 0;
        
        mouseX = Input.GetAxis("Mouse X");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speedFactor = 1.5f;
            isSprinting = true;
        }
        else
        {
            speedFactor = 1f;
            isSprinting = false;
        }

        if(Input.GetKeyDown(KeyCode.Space)&&isOnGround)
        {
            speedY = 5f;
        }
        
    }
    void ApplyMovement()

    {
        PlayerData.Instance.forwardSpeed = v_input*speedFactor*PlayerData.Instance.speedX;
        speedY += plGravity * Time.fixedDeltaTime;
        float verticalMovement =  speedY;
        Vector3 movement = new Vector3(0, verticalMovement, PlayerData.Instance.forwardSpeed);
        movement = this.transform.TransformDirection(movement);
        characterController.Move(movement * Time.deltaTime * 2f);
        PlayerData.Instance.aimPos = characterController.transform.position;
        PlayerData.Instance.aimRot = characterController.transform.rotation.eulerAngles;
   
    }
    void ApplyRotation()

    {
     transform.Rotate(0, mouseX*rotationSpeed*Time.fixedDeltaTime, 0);

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            characterController.enabled = false;
            GameState.Instance.curState = States.Player;
            
        }
        if (scene.buildIndex == 1)
        {
            characterController.enabled = false;
            transform.position = kampusStartPos;
            characterController.transform.position = kampusStartPos;
            Debug.Log(transform.position);
            characterController.enabled = true;
            EventManager.Fire_onWeatherEffectPosChanged(transform.position);

        }
        else if (scene.buildIndex == 2)
        {
            characterController.enabled = false;
            transform.position = lakeStartPos;
            characterController.transform.position = lakeStartPos;

            Debug.Log(transform.position);

            characterController.enabled = true;
            //player.transform.position = pos;

        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;


    }
}
