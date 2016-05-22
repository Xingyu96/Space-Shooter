using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 15f;

    private float xmax;
    private float xmin;
    private bool movingRight = true;
	// Use this for initialization
	void Start () {

        //for each position object in formation, spawn an enemy on top
        //foreach (Transform child in transform)
        //{
        //    GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
        //    enemy.transform.parent = child;
        //}
        SpawnFormation();

        //get boundaries of viewport
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftmost.x;
        xmax = rightmost.x;
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
	
	// Update is called once per frame
	void Update () {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        //check if formation is going out of the playspace
        float formation_right = transform.position.x + (0.5f * width);
        float formation_left = transform.position.x - (0.5f * width);
        if (formation_right > xmax)
        {
            movingRight = false;
        }
        else if (formation_left < xmin)
        {
            movingRight = true;
        }

        //respawn
        if (AllMembersDead())
        {
            SpawnFormation();
        }
	}

    bool AllMembersDead()
    {
        foreach(Transform childPositionGameObject in transform){
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnFormation()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }
}
