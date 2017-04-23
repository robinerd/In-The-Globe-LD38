using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    public bool dead = false;
    public float bulletSpeed = 200;
    public float shootInterval = 0.3f;
    public Transform bulletPrefab;

    float shootCooldown = 0.0f;
    int maxHp;

    [SyncVar]
    public int hp = 100;

    public void GetHurt()
    {
        if (!isServer)
        {
            return;
        }

        if (hp > 0)
        {
            hp -= 25;
            if (hp <= 0)
            {
                RpcRespawn();
                hp = 0;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        maxHp = hp;

        if (!isLocalPlayer)
            return;

        transform.position = Random.insideUnitSphere.normalized * 20;

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
                CmdShoot(Camera.main.transform.forward, base.netId.Value);

                shootCooldown = shootInterval;
            }
        }
    }
    
    [Command]
    void CmdShoot(Vector3 shootDirection, uint ownerPlayerID)
    {
        Transform bullet = Instantiate(bulletPrefab, transform.position - transform.up * 1.0f + shootDirection * 6f, Quaternion.identity) as Transform;
        if (bullet)
        {
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed + this.GetComponent<Rigidbody>().velocity;
            bullet.GetComponent<Bullet>().ownerPlayerID = ownerPlayerID;
            /*
            foreach (Collider partOfMe in GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(bullet.GetComponent<Collider>(), partOfMe);
            }*/
        }

        NetworkServer.SpawnWithClientAuthority(bullet.gameObject, gameObject);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        Camera.main.transform.parent = null;
        gameObject.SetActive(false);
        Invoke("SpawnHelper", 3.0f);
        dead = true;
    }

    void SpawnHelper()
    {
        gameObject.SetActive(true);
        dead = false;

        if (isLocalPlayer)
        {
            hp = maxHp;
            transform.position = Random.insideUnitSphere.normalized * 20;
        }
    }
}
