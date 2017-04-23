using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{
    public uint ownerPlayerID; //ONLY USED ON SERVER! will be 0 on client

    void OnCollisionEnter(Collision col)
    {
        if (isServer)
        {
            Player playerHit = col.collider.GetComponent<Player>();
            if (playerHit != null && playerHit.netId.Value != ownerPlayerID)
            {
                playerHit.GetHurt();
            }
        }

        Destroy(gameObject, 1.6f);
    }

}
