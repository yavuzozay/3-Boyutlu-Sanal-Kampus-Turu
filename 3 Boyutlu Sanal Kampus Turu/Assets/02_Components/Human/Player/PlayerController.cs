using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    //Input
    private float h_input;
    private float v_input;
    private float mouseX;
    [Range(1, 4)] [SerializeField] float speedFactor;
    
    [SerializeField] float rotationSpeed;
    
    
    [SerializeField] float mouseSensivity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        CheckInput();
    }
    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }
    void CheckInput()
    {
        // h_input = Input.GetAxisRaw("Horizontal");
        v_input = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speedFactor = 2f;
        }
        else
        {
            speedFactor = 1f;
        }
        
    }
    void ApplyMovement()

    {
        PlayerData.Instance.forwardSpeed = v_input*speedFactor;
        Vector3 movement = new Vector3(h_input, 0, PlayerData.Instance.forwardSpeed);
        Debug.Log(PlayerData.Instance.forwardSpeed);
        movement = this.transform.TransformDirection(movement);
        characterController.Move(movement * Time.deltaTime * 2f);
        PlayerData.Instance.aimPos = characterController.transform.position;
        PlayerData.Instance._aimRot = characterController.transform.rotation.eulerAngles;
         Debug.Log( characterController.velocity);
    }
    void ApplyRotation()

    {
     transform.Rotate(0, mouseX*rotationSpeed*Time.fixedDeltaTime, 0);

    }
}
