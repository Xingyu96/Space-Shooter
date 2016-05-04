using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 15f;
    public float padding = 0.5f;

    private Vector3 position;
    private float xmin;
    private float xmax;

    void Start()
    {
        //determine leftmost and rightmost coordinates
        float distanceZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
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

        //restrict player to gamescpace
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), transform.position.y, transform.position.z);

	}
}
