using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightLeftMove : MonoBehaviour
{
    float direction=1;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 4)
        {
            direction = -0.3f;
        }
        else if (transform.position.z < -4)
        {
            direction = .3f;
        }

            transform.Translate(0, 0, direction);
    }

}
