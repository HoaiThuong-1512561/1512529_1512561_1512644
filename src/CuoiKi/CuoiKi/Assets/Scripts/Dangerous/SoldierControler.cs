using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierControler : MonoBehaviour {
    public float speed = 8f;
    public float maxVelocity = 2f;

    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    private int Direction = 3;//1=left 2=right 3=up 4=down
    private bool left = false;
    private bool right = false;
    private bool up = false;
    private bool down = false;
    int loop = 0;

    bool isDetroy = false;
    int timeDetroy = 0;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Direction = Random.Range(1, 5);
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        if (!isDetroy)
        {
            Move();
        }
        else
        {
            myBody.velocity = Vector3.zero;
            timeDetroy++;
            if (timeDetroy == 100)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        int rand = Random.Range(1, 5);
        while (rand == Direction)
        {
            rand = Random.Range(1, 5);
        }
        Direction = rand;
    }
    void OnCollisionStay2D(Collision2D other)
    {

        loop++;
        if (loop > 25)
        {
            int rand = Random.Range(1, 5);
            while (rand == Direction)
            {
                rand = Random.Range(1, 5);
            }
            Direction = rand;
            loop = 0;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            isDetroy = true;
            anim.Play("soldier_detroy", -1, 0f);
            //Destroy(this.gameObject);
        }


    }
    void Move()
    {
        float forxeY = 0f;
        float forxeX = 0f;

        float moveSpeed = 1f;
        Vector3 dir = new Vector3();
        switch (Direction)
        {
            case 1:
                forxeX = -speed;
                if (!left)
                {
                    left = true;
                    right = false;
                    up = false;
                    down = false;
                    anim.Play("soldier_left", -1, 0f);

                }
                dir = new Vector3(forxeX, 0, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;
            case 2:
                if (!right)
                {
                    left = false;
                    right = true;
                    up = false;
                    down = false;
                    anim.Play("soldier_right", -1, 0f);

                }
                forxeX = speed;
                dir = new Vector3(forxeX, 0, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;
            case 3:
                if (!up)
                {
                    left = false;
                    right = false;
                    up = true;
                    down = false;
                    anim.Play("soldier_up", -1, 0f);

                }
                forxeY = speed;
                dir = new Vector3(0, forxeY, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;
            case 4:
                if (!down)
                {
                    left = false;
                    right = false;
                    up = false;
                    down = true;
                    anim.Play("soldier_down", -1, 0f);

                }
                forxeY = -speed;
                dir = new Vector3(0, forxeY, 0f);
                dir = dir.normalized;
                myBody.velocity = dir * moveSpeed;
                break;

        }
        forxeX = 0;
        forxeY = 0;

    }
}
