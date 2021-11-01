using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStickController : MonoBehaviour
{
    //Transform
    private Transform mT;
    private Vector3 curPos;
    private Quaternion curRot;
   [SerializeField]  private Vector3 posOffset;

    public GameObject brain;


    //Rotate Angles
    [SerializeField]private float rotAngleX;
    private float rotAngleY;
    private Quaternion aimRot;
    [SerializeField] Transform lookAt;
    Quaternion offsettRotation;
 

    private void Awake()
    {
        mT = transform;
        curRot = mT.rotation;
        curPos = mT.position;
        //brain.GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = lookAt;
      
    }
    private void Start()
    {
     
        offsettRotation = transform.rotation * Quaternion.Inverse(lookAt.rotation);
    }

    private void FixedUpdate()
    {

        FollowPlayer();
        RotateCam();


    }
    private void FollowPlayer()
    {
        curPos = Vector3.Lerp(curPos, PlayerData.Instance.aimPos + posOffset, Time.fixedDeltaTime * 3);
        mT.position = curPos;
    }
    private void RotateCam()
    {
  

    }

}
