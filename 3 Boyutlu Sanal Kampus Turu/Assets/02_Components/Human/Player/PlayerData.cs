using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoSingleton<PlayerData>
{
    //Transform
    private Vector3 _aimPos;

    private Vector3 _aimRot;

    //Speed
    private float _forwardSpeed;
    private float _horizontalSpeed;
    [SerializeField] private float _speedX;


    #region speed getter&setter
    public float speedX
    {
        get { return _speedX; }

    }
    public float forwardSpeed
    {
        get { return this._forwardSpeed; }
        set { this._forwardSpeed = value; }
    }
    public float horizontalSpeed
    {
        get { return this._horizontalSpeed; }
        set { this._horizontalSpeed = value; }
    }
    #endregion


    #region transform getter&setter
    public Vector3 aimPos
        {
        get{ return _aimPos; }
        set { this._aimPos = value; }
    }
    public Vector3 aimRot
    {
        get { return _aimRot; }
        set { this._aimRot =value; }
    }
    #endregion
}
