using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float health = 150f;
    public float laserspeed = 10f;
    public GameObject laserPrefab;
    public float fireRate = 0.2f;
    public float shotsPerSeconds = 0.5f;
    public int value = 150;

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
                //lvlScore.Score(250);
                GameObject.FindObjectOfType<ScoreKeeper>().Score(value);

            }
        }
    }

    void Update()
    {
        //to deal with frame rates
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability)
        {
            Fire();
        }


 
    }

    void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserspeed);
    }
}
