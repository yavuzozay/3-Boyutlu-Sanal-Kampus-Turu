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
        h_input = Input.GetAxisRaw("Horizontal");
        v_input = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        
    }
    void ApplyMovement()

    {
        Vector3 movement = new Vector3(h_input, 0, v_input).normalized;
        movement = this.transform.TransformDirection(movement);
        characterController.Move(movement * Time.deltaTime * 2f);
        PlayerData.Instance.aimPos = characterController.transform.position;
        // Debug.Log( characterController.velocity);
    }
    void ApplyRotation()

    {
     transform.Rotate(0, mouseX*rotationSpeed*Time.fixedDeltaTime, 0);

    }
}
