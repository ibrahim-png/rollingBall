using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTextScript : MonoBehaviour
{
    public float destroyTime = 1f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
