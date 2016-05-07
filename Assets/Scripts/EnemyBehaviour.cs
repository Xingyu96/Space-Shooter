using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float health = 150f;

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("collision");
        Projectile laser = col.gameObject.GetComponent<Projectile>();
        if (laser)
        {
            //get damage done by laser; destroy incoming laser object
            health -= laser.GetDamage();
            laser.Hit();
            //destroy enemy ship if health less than lollllllll
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
