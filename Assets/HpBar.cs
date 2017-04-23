using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour {

    Player owner;
    RectTransform bar;
   
    // Use this for initialization
    void Awake () {
        owner = GetComponentInParent<Player>();
        bar = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        bar.sizeDelta = new Vector2(owner.hp, bar.sizeDelta.y);
    }
}
