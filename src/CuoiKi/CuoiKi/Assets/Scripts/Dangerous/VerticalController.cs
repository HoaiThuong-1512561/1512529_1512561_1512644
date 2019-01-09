using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalController : MonoBehaviour {
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
    void OnCollisionEnter2D(Collision2D other)
    {
        Direction = Direction + 1;
        if (Direction == 3)
        {
            Direction = 1;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }
    void Move()
    {
        float forxeY = 0f;
        Vector3 dir = new Vector3();
        switch (Direction)
        {
            case 1:
                anim.SetBool("up", false);
                anim.SetBool("down", true);
                forxeY = -speed;
                dir = new Vector3(0, forxeY, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;
            case 2:

                anim.SetBool("down", false);
                anim.SetBool("up", true);
                forxeY = speed;
                dir = new Vector3(0, forxeY, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;
        }
        forxeY = 0;
    }
}
