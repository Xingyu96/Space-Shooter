using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("shred");
        Destroy(col.gameObject);
    }
}
