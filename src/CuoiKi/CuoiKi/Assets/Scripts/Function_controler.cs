using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function_controler: MonoBehaviour
{

    public GameObject gameObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setScale(float scale)
    {
        gameObject.transform.localScale = new Vector3(scale, scale, 0);
    }
}
