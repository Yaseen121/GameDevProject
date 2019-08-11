﻿using UnityEngine;
using System.Collections;

public class WreckingBall : MonoBehaviour
{
    #region Public Variables
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
    #endregion //Public Variables

    #region Private Variables

    #endregion //Private Variables

    // (Unity Named Methods)
    #region Main Methods
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }
    //Update is called by Unity every frame
    void Update()
    {
        Push();
    }
    #endregion //Main Methods

    //(Custom Named Methods)
    #region Utility Methods 
    public void Push()
    {
        if (transform.rotation.z > 0
            && transform.rotation.z < rightPushRange
            && (body2d.angularVelocity > 0)
            && body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0
            && transform.rotation.z > leftPushRange
            && (body2d.angularVelocity < 0)
            && body2d.angularVelocity > velocityThreshold * -1)
        {
            body2d.angularVelocity = velocityThreshold * -1;
        }

    }
    #endregion //Utility Methods

    //Coroutines run parallel to other fucntions
    #region Coroutines

    #endregion //Coroutines
}