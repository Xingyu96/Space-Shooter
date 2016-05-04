using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 15f;

    private Vector3 position;
    private float xmin = -5f;
    private float xmax = 5f;

	
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
