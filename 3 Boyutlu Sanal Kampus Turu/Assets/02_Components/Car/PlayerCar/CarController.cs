using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public class CarController : MonoBehaviour
{

    [SerializeField] private float maxAcceleration = 20.0f;
    [SerializeField] private float turnSensitivity = 1.0f;
    [SerializeField] private float maxSteerAngle = 45.0f;
    [SerializeField] private Vector3 _centerOfMass;
    [SerializeField] private List<Wheel> wheels;
    [SerializeField] TextMeshProUGUI carSpeedText;
    [SerializeField]private bool _isInteractedThis=false;
    private float speed=0;
    private GameObject player;
    private GameObject shortLight,longLight,LightParent;
    private int curLightMode = 0;//o kapalý 1 kýsa 2 uzun.
  
    public bool isInteractedThis
    {
        get { return _isInteractedThis; }
        set { _isInteractedThis = value; }
    }
    private float inputX, inputY;

    private Rigidbody _rb;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        LightParent = transform.GetChild(4).gameObject;
        shortLight = LightParent.transform.GetChild(0).gameObject;
        longLight = LightParent.transform.GetChild(1).gameObject;
        
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = _centerOfMass;
    }


    private void Update()
    {
        if (GameState.Instance.curState != States.Car)
        {
            _rb.velocity = new Vector3(0, 0, 0);
            carSpeedText.SetText("");
            return;
        }
       if(isInteractedThis)
        {
            AnimateWheels();
            CheckInputs();
            speed = (_rb.velocity.magnitude * 3.6f);
            carSpeedText.SetText("Speed :" + Math.Round(speed, 2) + "KM/H");
        }
        else
        {
            _rb.velocity = new Vector3(0, 0, 0);

        }

    }

    private void FixedUpdate()
    {
        if(isInteractedThis)
        {
            player.SetActive(false);

            Move();
            Turn();
        }
      
    }

    private void CheckInputs()
    {
       
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        if (_rb.velocity.magnitude > 15f)
        {
            inputY = 0;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            curLightMode++;
            if(curLightMode==3) curLightMode=0;
            CarLights();


        }
        if(Input.GetKeyDown(KeyCode.F))
        {

            GameState.Instance.curState = States.Player;
            player.transform.position = transform.position - transform.right * 2;
            player.SetActive(true);


            _isInteractedThis = false;
        }
    }
    private void CarLights()
    {
        switch (curLightMode)
        {
            case 0: {
                    shortLight.SetActive(false);
                    longLight.SetActive(false);
                }break;
            case 1: {
                    shortLight.SetActive(true);
                    longLight.SetActive(false);
                }
                break;
            case 2: {
                    shortLight.SetActive(false);
                    longLight.SetActive(true);
                }
                break;
            default: {
                    shortLight.SetActive(false);
                    longLight.SetActive(false);
                } break;
        }
    }
    private void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.fixedDeltaTime;
        }
    }
 
    private void Turn()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f);
            }
        }
    }

    private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }
}