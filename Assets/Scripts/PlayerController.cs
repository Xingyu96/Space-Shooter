using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 1.0f;

    private Vector3 position;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= new Vector3(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }

	}
}
