using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    //public Player owner;

    void OnCollisionEnter(Collision col)
    {
        Player playerHit = col.collider.GetComponent<Player>();
        if (playerHit != null)
        {
            playerHit.Hurt();
        }
        Destroy(gameObject, 1.6f);
    }

}
