using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    public float bulletSpeed = 200;
    public float shootInterval = 0.3f;
    public Transform bulletPrefab;

    float shootCooldown = 0.0f;
    int hp = 10;

    public void Hurt()
    {
        if (hp > 0)
        {
            hp--;
            if (hp <= 0)
            {
                Debug.Log("DED!");
                hp = 0;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
            return;

        foreach (Collider partOfMe in GetComponentsInChildren<Collider>())
        {
            partOfMe.gameObject.layer = LayerMask.NameToLayer("localPlayer");
        }
        Camera.main.GetComponent<CamFollow>().localPlayer = transform;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        shootCooldown -= Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            if (shootCooldown <= 0.0f)
            {
                Transform bullet = Instantiate(bulletPrefab, transform.position + transform.up * 0.35f + transform.right * 1.6f, Quaternion.identity) as Transform;
                if(bullet)
                {
                    bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed + this.GetComponent<Rigidbody>().velocity;
                }
                shootCooldown = shootInterval;
            }
        }
    }
}
