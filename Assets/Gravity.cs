using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public float gravity = 10;

    float radius;

    // Use this for initialization
    void Start () {
        radius = transform.localScale.x * GetComponent<SphereCollider>().radius;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach(Rigidbody body in FindObjectsOfType<Rigidbody>())
        {
            if (body.isKinematic)
                continue;

            Vector3 fromCenter = body.position - transform.position;
            Vector3 up = -(fromCenter.normalized);

            //HANDLE GRAVITY
            body.AddForce(-up * gravity, ForceMode.Acceleration);

            Vector3 axis = Vector3.Cross(body.transform.up, up) * 400;
            Vector3 torque = axis * Vector3.Angle(body.transform.up, up); 
            body.AddTorque(axis, ForceMode.Acceleration);
            //body.transform.Rotate(Quaternion.FromToRotation(body.transform.up, up).eulerAngles, Space.World);
        }
	}
}
