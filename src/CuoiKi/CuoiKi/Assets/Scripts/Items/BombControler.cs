using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControler : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ghost")|| other.gameObject.CompareTag("Soldier") || other.gameObject.CompareTag("animal"))
            Destroy(this.gameObject);

    }
    // Update is called once per frame
    void Update () {
		
	}
   
}
