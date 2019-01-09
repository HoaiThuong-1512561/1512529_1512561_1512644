using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizonController : MonoBehaviour {
    public float speed = 4f;
    public float moveSpeed = 2f;

    //[SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    private int Direction = 1;//1=left 2=right 3=up 4=down

    // Use this for initialization
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Direction = Random.Range(1, 3);
    }
    void Start () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        Direction = Direction+1;
        if (Direction == 3)
        {
            Direction = 1;
        }
    }
    // Update is called once per frame
    void Update () {
        Move();
	}
    void Move()
    {
        float forxeX = 0f;
        Vector3 dir = new Vector3();
        switch (Direction)
        {
            case 1:
                anim.SetBool("right", false);
                anim.SetBool("left", true);
                forxeX = -speed;
                dir = new Vector3(forxeX, 0, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;
            case 2:

                anim.SetBool("left", false);
                anim.SetBool("right", true);
                forxeX = speed;
                dir = new Vector3(forxeX, 0, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;
        }
        forxeX = 0;
    }
}
