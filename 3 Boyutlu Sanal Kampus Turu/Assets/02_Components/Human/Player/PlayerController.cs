using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    //Input
    private float h_input;
    private float v_input;
    
    [SerializeField] float RotationSpeed;
    
    
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
    }
    void CheckInput()
    {
        h_input = Input.GetAxisRaw("Horizontal");
        v_input = Input.GetAxisRaw("Vertical");
    }
    void ApplyMovement()

    {
        Vector3 movement = new Vector3(h_input, 0, v_input).normalized;
        characterController.Move(movement * Time.deltaTime * 2f);
    }
}
