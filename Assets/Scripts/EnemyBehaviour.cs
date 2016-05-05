using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("collision");
        Projectile laser = col.gameObject.GetComponent<Projectile>();
        if (laser)
        {
            Debug.Log("hit by a laser");
        }
    }
}
