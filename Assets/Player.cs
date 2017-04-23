using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

    public MouseLook mouseLook;
    public float ForwardSpeed = 8.0f;   // Speed when walking forward
    public float BackwardSpeed = 4.0f;  // Speed when walking backwards
    public float StrafeSpeed = 4.0f;    // Speed when walking sideways
    public float JumpForce = 30f;

    // Use this for initialization
    void Start()
    {
        mouseLook.Init(transform, Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook.LookRotation(transform, Camera.main.transform);
        
    }

    void FixedUpdate()
    {
        mouseLook.UpdateCursorLock();
    }
}
