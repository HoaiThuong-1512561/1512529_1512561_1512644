using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Vector2 minPos;
    public Vector2 maxPos;
    public GameObject player;

    private void FixedUpdate()
    {
        FollowPlayer();

        CheckOutScreen();
    }

    private void FollowPlayer()
    {
        Vector3 newPos = player.transform.position;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }

    private void CheckOutScreen()
    {
        if (transform.position.x < minPos.x)
        {
            Vector3 newPos = transform.position;
            newPos.x = minPos.x;
            transform.position = newPos;
        }
        if (transform.position.y < minPos.y)
        {
            Vector3 newPos = transform.position;
            newPos.y = minPos.y;
            transform.position = newPos;
        }
        if (transform.position.x > maxPos.x)
        {
            Vector3 newPos = transform.position;
            newPos.x = maxPos.x;
            transform.position = newPos;
        }
        if (transform.position.y > maxPos.y)
        {
            Vector3 newPos = transform.position;
            newPos.y = maxPos.y;
            transform.position = newPos;
        }
    }
}
