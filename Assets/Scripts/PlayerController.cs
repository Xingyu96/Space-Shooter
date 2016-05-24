using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 15f;
    public float laserspeed = 10f;
    public float padding = 0.5f;
    public GameObject laserPrefab;
    public float fireRate = 0.2f;
    public AudioClip firesound;
    public AudioClip death;

    private float xmin;
    private float xmax;

    private float health = 250f;

    //private LevelManager lvlManager;
    private TextManager textManager;

    void Start()
    {
        //determine leftmost and rightmost coordinates
        float distanceZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;

        //instantiate lvlManager
        //lvlManager = GameObject.FindObjectOfType<LevelManager>();
        textManager = GameObject.FindObjectOfType<TextManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke();
        }

        //restrict player to gamescpace
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), transform.position.y, transform.position.z);

	}

    void Fire()
    {
        Vector3 offset = new Vector3(0, 1f, 0);
        GameObject laser = Instantiate(laserPrefab, transform.position , Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserspeed, 0);
        AudioSource.PlayClipAtPoint(firesound, transform.position);
    }

    //take damage and die if hit by enemy laser too many times
    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile laser = col.gameObject.GetComponent<Projectile>();
        if (laser)
        {
            //get damage done by laser; destroy incoming laser object
            health -= laser.GetDamage();
            laser.Hit();
            //destroy player if health less than 0
            //currently set to trigger lose screen
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
        textManager.DisplayLose();
        AudioSource.PlayClipAtPoint(death, transform.position);
    }
}
