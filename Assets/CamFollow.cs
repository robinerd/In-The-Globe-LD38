using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public Transform localPlayer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (localPlayer != null && !localPlayer.GetComponent<Player>().dead) {
            transform.parent = localPlayer;
            transform.localPosition = new Vector3(0, 0.6f, 0.4f);
        }
        else
        {
            transform.parent = null;
        }
	}
}
