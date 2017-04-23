using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootAnimation : MonoBehaviour {

    ConfigurableJoint joint;
    Vector3 anchorOrig;
    public float phase = 0;

	// Use this for initialization
	void Start () {
        joint = GetComponent<ConfigurableJoint>();
        anchorOrig = joint.connectedAnchor;
        joint.autoConfigureConnectedAnchor = false;
	}
	
	// Update is called once per frame
	void Update () {
        joint.connectedAnchor = anchorOrig + Vector3.up * (0.2f + 0.1f * Mathf.Sin(phase + Time.time * 18));

    }
}
