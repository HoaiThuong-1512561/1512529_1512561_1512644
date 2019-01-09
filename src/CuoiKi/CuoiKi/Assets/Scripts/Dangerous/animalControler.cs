using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalControler : MonoBehaviour {
    public GameObject keyObject;
	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            int rand = Random.Range(1, 15);
            if (Data.numberAnimal == 1)
            {
                rand = 10;
            }
            if (rand == 10)
            {
                Instantiate(keyObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            Destroy(this.gameObject);
            Data.numberAnimal--;
        }


    }
    // Update is called once per frame
    void Update () {
		
	}
}
