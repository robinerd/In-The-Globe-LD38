using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBillboard : MonoBehaviour {

    Player parentPlayer;

    // Use this for initialization
    void Start ()
    {
        parentPlayer = GetComponentInParent<Player>();
        if(parentPlayer.isLocalPlayer)
        {
            transform.parent = Camera.main.transform;
            //transform.localPosition = new Vector3(0.0f, -0.7f, 1.8f);
            //transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!parentPlayer.isLocalPlayer)
        {
            transform.LookAt(Camera.main.transform, parentPlayer.transform.up);
        }
    }
}
