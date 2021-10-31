using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStickController : MonoBehaviour
{
    private Transform mT;
    private Vector3 curPos;
    [SerializeField] private Vector3 posOffset;

    private void Awake()
    {
        mT = transform;
        curPos = mT.position;
    }
    private void FixedUpdate()
    {
        curPos = Vector3.Lerp(curPos, PlayerData.Instance.aimPos+posOffset, Time.fixedDeltaTime * 3);
        mT.position = curPos;
        
    }
}
