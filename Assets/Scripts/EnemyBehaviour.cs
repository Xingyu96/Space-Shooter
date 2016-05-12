using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float health = 150f;
    public float laserspeed = 10f;
    public GameObject laserPrefab;
    public float fireRate = 0.2f;

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

    void Update()
    {
        //fire laser
        //InvokeRepeating("Fire", 0.000001f, fireRate);
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        GameObject laser = Instantiate(laserPrefab, startPosition, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserspeed);
      

    }

    void Fire()
    {
        //GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        //laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserspeed, 0);
    }
}
